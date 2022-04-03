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
                movimientos[x].cantidad_Actual = producto.cantidad;
                movimientos[x].codigo_Actual = producto.codigo;
            }

            
            dgvCarritoSalida.DataSource = movimientos;

            this.dgvCarritoSalida.Columns["dispositivo"].Visible = false;
            this.dgvCarritoSalida.Columns["foto"].Visible = false;
            this.dgvCarritoSalida.Columns["foto2"].Visible = false;
            this.dgvCarritoSalida.Columns["comentarios"].Visible = false;
            this.dgvCarritoSalida.Columns["LugarId"].Visible = false;
            this.dgvCarritoSalida.Columns["comentarios"].Visible = false;
            this.dgvCarritoSalida.Columns["usuario"].Visible = false;
            this.dgvCarritoSalida.Columns["usuarioId"].Visible = false;
            this.dgvCarritoSalida.Columns["idMovimiento"].Visible = false;
            this.dgvCarritoSalida.Columns["fechaAlta"].Visible = false;
            this.dgvCarritoSalida.Columns["tipoMovimiento"].Visible = false;
            this.dgvCarritoSalida.Columns["fechaUltimaModificacion"].Visible = false;
            this.dgvCarritoSalida.Columns["dispositivoId"].Visible = false;
            this.dgvCarritoSalida.Columns["tipoMovId"].Visible = false;
            this.dgvCarritoSalida.Columns["nombre_Actual"].Visible = false;
            this.dgvCarritoSalida.Columns["tipo_Actual"].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }
    }
}
