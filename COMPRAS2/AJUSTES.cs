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

namespace COMPRAS2
{
    public partial class AJUSTES : Form
    {
        public AJUSTES()
        {
            InitializeComponent();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void linkInformacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Aqui informacion de la aplicacion");
        }

        private void AJUSTES_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }
    }
}
