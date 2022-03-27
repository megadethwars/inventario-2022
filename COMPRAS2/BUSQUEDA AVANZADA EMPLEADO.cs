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
    public partial class BUSQUEDA_AVANZADA_EMPLEADO : Form
    {
        public BUSQUEDA_AVANZADA_EMPLEADO()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Introduzca el Nombre")
            {
                txtNombre.Clear();
            }
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Introduzca el Correo")
            {
                txtCorreo.Clear();
            }
        }

        private void BUSQUEDA_AVANZADA_EMPLEADO_Load(object sender, EventArgs e)
        {

        }
    }
}
