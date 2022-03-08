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
    public partial class REPORTES : Form
    {
        public REPORTES()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnOPCIONES_Click(object sender, EventArgs e)
        {
            //Navigator.nextPage(new REPORTES2());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
        
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Escriba Aqui";
                //txtDescripcion.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }

        private void txtNombreDelProducto_Click(object sender, EventArgs e)
        {
            txtNombreDelProducto.Clear();
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
        }

        private void txtNombreDelProducto_Leave(object sender, EventArgs e)
        {
            if (txtNombreDelProducto.Text == "")
            {
                txtNombreDelProducto.Text = "Producto";
                //txtDescripcion.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }
    }
}
