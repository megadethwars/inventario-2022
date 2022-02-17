using COMPRAS2.modelos;
using COMPRAS2.servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMPRAS2.servicios;
namespace COMPRAS2
{
    public partial class MIPERFIL : Form
    {
        MENU mainmenu;

        public MIPERFIL()
        {
            InitializeComponent();

            this.nombre1.Text = CurrentUser.nombre;
            this.telefono1.Text = CurrentUser.telefono;
            this.correo1.Text = CurrentUser.correo;
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

        string url = "https://avsinventoryswagger.azurewebsites.net/api/v1/";
   

        private void MIPERFIL_Load(object sender, EventArgs e)
        {
            var url = HttpMethods.url + "usuarios";
        }
        /*
        ~MIPERFIL() {
            int a = 0;
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name,this);     
        }
    }
}
