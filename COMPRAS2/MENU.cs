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
    public  partial class MENU : Form
    {
        MENU2 mainmenu;
        public int a = 0;
        public MENU()
        {
            mainmenu = new MENU2(this);
            InitializeComponent();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            AbrirFormHija(mainmenu);
        }

        private void MENU_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.PANELCONTENEDOR.Controls.Count > 0)
                this.PANELCONTENEDOR.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PANELCONTENEDOR.Controls.Add(fh);
            this.PANELCONTENEDOR.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            
            //Control[] controls = this.PANELCONTENEDOR.Controls.Find("MIPERFIL", true);

            foreach (Control control in this.PANELCONTENEDOR.Controls) {
                control.Dispose();
            }
            
  
            if (this.PANELCONTENEDOR.Controls.Count > 0)
                this.PANELCONTENEDOR.Controls.RemoveAt(0);
            
            

            AbrirFormHija(mainmenu);
            /*try
            {

                Control[] controls = this.PANELCONTENEDOR.Controls.Find("MIPERFIL", true);
                
                controls[0].Dispose();
                if (this.PANELCONTENEDOR.Controls.Count > 0)
                    this.PANELCONTENEDOR.Controls.RemoveAt(0);

                AbrirFormHija(mainmenu);
            }
            catch
            {
                MessageBox.Show("EXCESO DE VISTAS...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            
        }

       

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            INICIARSESION iniciarsesion = new INICIARSESION();
            iniciarsesion.Show();
            this.Dispose();
        }
        
        private void PANELCONTENEDOR_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
