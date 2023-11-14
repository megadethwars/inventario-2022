﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using COMPRAS2.modelos;
using COMPRAS2.servicios;
namespace COMPRAS2
{
    public partial class MENU2 : Form
    {
        MENU mainmenu;
        System.Timers.Timer timer;
        System.Timers.Timer timer2;
        public MENU2(MENU mainMenu)
        {
            InitializeComponent();
            this.mainmenu = mainMenu;

            this.lbUsername.Text = CurrentUsers.username;
            timer = new System.Timers.Timer(300000);
            timer.Elapsed += TimerElapsed;
            timer.Start();

            timer2 = new System.Timers.Timer(451000);
            timer2.Elapsed += TimerElapsed2;
            timer2.Start();
        }

        private void ManejarEvento(int dato)
        {
            // Actualizar el formulario con el dato recibido
            if (dato == 1) {
                this.lbStatus.Text = "Sincronizacion pendiente..";
            }

            if (dato == 0) {
                this.lbStatus.Text = "Sincronizacion Completa";
            }
            
        }

        private  void TimerElapsed(object sender, ElapsedEventArgs e)
        {

            SyncMoveManager.SyncMovesToAzurethread();
        }

        private void TimerElapsed2(object sender, ElapsedEventArgs e)
        {

            SyncMoveManager.deleteMovesSqlite();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        
        private void AbrirFormHija(object formhija)
        {                      
            if (this.mainmenu.PANELCONTENEDOR.Controls.Count > 0)
                this.mainmenu.PANELCONTENEDOR.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mainmenu.PANELCONTENEDOR.Controls.Add(fh);
            this.mainmenu.PANELCONTENEDOR.Tag = fh;
            fh.Show();
        }
        
        private void MIPERFIL_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Navigator.nextPage(new pruebaSQLITE());
            //Navigator.nextPage(new MIPERFIL());
        }       

        private void btnREPORTE_Click(object sender, EventArgs e)
        {            
            Navigator.nextPage(new REPORTES2());
        }

        private void btnINVENTARIO_Click(object sender, EventArgs e)
        {            
            Navigator.nextPage(new INVENTARIO());
        }

        private void btnEMPLEADOS_Click(object sender, EventArgs e)
        {         
            Navigator.nextPage(new EMPLEADOS());
        }

        private void btnAJUSTES_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new AJUSTES());
        }

        private void btnHISTORIAL_Click(object sender, EventArgs e)
        {          
            Navigator.nextPage(new HIST() { Name="HIST"});
        }

        private void MENU2_Load(object sender, EventArgs e)
        {

        }

        ~MENU2()
        {
            timer.Stop();
        } 
    }
}
