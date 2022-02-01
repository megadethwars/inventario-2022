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
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new MENU2());
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
            AbrirFormHija(new MIPERFIL());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new INVENTARIO());
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new HISTORIAL());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new EMPLEADOS());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new REPORTES());
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new AJUSTES());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            INICIARSESION iniciarsesion = new INICIARSESION();
            iniciarsesion.Show();
            this.Hide();
        }

        private void PANELCONTENEDOR_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
