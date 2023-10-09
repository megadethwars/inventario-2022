using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMPRAS2.modelos;
using COMPRAS2.servicios;
namespace COMPRAS2
{
    public partial class MENU2 : Form
    {
        MENU mainmenu;

        public MENU2(MENU mainMenu)
        {
            InitializeComponent();
            this.mainmenu = mainMenu;

            this.lbUsername.Text = CurrentUsers.username;
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
    }
}
