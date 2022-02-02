using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPRAS2
{
    public partial class MENU2 : Form
    {

        MENU mainmenu;

        public MENU2(MENU mainMenu)
        {
            InitializeComponent();
            this.mainmenu = mainMenu;
            
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
            //this.BackColor = Color.FromArgb(0, 0, 0);
            //is.Hide();
            //this.Dispose();
            AbrirFormHija(new MIPERFIL());

        }

        private void HISTORIAL_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new HISTORIAL());
        }

        private void btnREPORTE_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new REPORTES());
        }

        private void btnINVENTARIO_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new INVENTARIO());
        }

        private void btnEMPLEADOS_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new EMPLEADOS());
        }

        private void btnAJUSTES_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new AJUSTES());
        }
    }
}
