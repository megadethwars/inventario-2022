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
    public partial class CarritoSalida : Form
    {
        SALIDA salida;
        public CarritoSalida(SALIDA salida)
        {
            InitializeComponent();
            this.salida = salida;
        }

        private void btBack_Click(object sender, EventArgs e)
        {

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

        private void CarritoSalida_Load(object sender, EventArgs e)
        {
            //instanciate lista
        }
    }
}
