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

namespace COMPRAS2
{
    public partial class CarritoSalida : Form
    {
        SALIDA salida;
        public List<Movimientos> movimientos;
        public CarritoSalida(SALIDA salida)
        {
            InitializeComponent();
            this.salida = salida;

            this.movimientos = this.salida.movimientos;
        }
        

        private void CarritoSalida_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < movimientos.Count; x++)
            {

                Devices producto = movimientos[x].dispositivo;
                movimientos[x].dispositivo_Actual = producto.producto;

                
            }

            //instanciate lista
            dgvCarritoSalida.DataSource = movimientos;

            //this.dgvInventario.Columns["dispositivo"].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }
    }
}
