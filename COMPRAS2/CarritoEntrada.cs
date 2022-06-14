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
    public partial class CarritoEntrada : Form
    {
        public List<Movimientos> movimientos;
        DataGridViewButtonColumn btnclm;
        public ENTRADA entrada;
        public CarritoEntrada(ENTRADA entrada)
        {
            InitializeComponent();
            this.entrada = entrada;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void CarritoEntrada_Load(object sender, EventArgs e)
        {
            dgvCarritoEntrada.Columns.Add("Codigo", "Codigo");
            dgvCarritoEntrada.Columns.Add("Producto", "Producto");
            dgvCarritoEntrada.Columns.Add("Cantidad", "Cantidad");
            //dgvCarritoSalida.Columns[0].Name = "Codigo";
            //dgvCarritoSalida.Columns[1].Name = "Producto";
            //dgvCarritoSalida.Columns[2].Name = "Cantidad";

            for (int x = 0; x < movimientos.Count; x++)
            {
                Devices producto = movimientos[x].dispositivo;
                movimientos[x].dispositivo_Actual = producto.producto;
                movimientos[x].cantidad_Actual = producto.cantidad_de_productos;
                movimientos[x].codigo_Actual = producto.codigo;
                string[] row = new string[] { movimientos[x].codigo_Actual, movimientos[x].dispositivo_Actual, movimientos[x].cantidad_Actual.ToString() };
                dgvCarritoEntrada.Rows.Add(row);
            }

            //dgvCarritoSalida.DataSource = movimientos;

            //this.dgvCarritoSalida.Columns["dispositivo"].Visible = false;
            //this.dgvCarritoSalida.Columns["foto"].Visible = false;
            //this.dgvCarritoSalida.Columns["foto2"].Visible = false;
            //this.dgvCarritoSalida.Columns["comentarios"].Visible = false;
            //this.dgvCarritoSalida.Columns["LugarId"].Visible = false;
            //this.dgvCarritoSalida.Columns["comentarios"].Visible = false;
            //this.dgvCarritoSalida.Columns["usuario"].Visible = false;
            //this.dgvCarritoSalida.Columns["usuarioId"].Visible = false;
            //this.dgvCarritoSalida.Columns["idMovimiento"].Visible = false;
            //this.dgvCarritoSalida.Columns["fechaAlta"].Visible = false;
            //this.dgvCarritoSalida.Columns["tipoMovimiento"].Visible = false;
            //this.dgvCarritoSalida.Columns["fechaUltimaModificacion"].Visible = false;
            //this.dgvCarritoSalida.Columns["dispositivoId"].Visible = false;
            //this.dgvCarritoSalida.Columns["tipoMovId"].Visible = false;
            //this.dgvCarritoSalida.Columns["nombre_Actual"].Visible = false;
            //this.dgvCarritoSalida.Columns["tipo_Actual"].Visible = false;

            btnclm = new DataGridViewButtonColumn();
            btnclm.Name = "El";
            btnclm.Text = "Eliminar";
            btnclm.HeaderText = "Eliminar";
            btnclm.UseColumnTextForButtonValue = true;
            this.dgvCarritoEntrada.Columns.Add(btnclm);
        }


        private void dgvCarritoSalida_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvCarritoEntrada.Columns.IndexOf(btnclm))
            {
                try
                {
                    //DataGridViewRow row = dgvCarritoSalida.Rows[e.RowIndex];
                    dgvCarritoEntrada.Rows.RemoveAt(dgvCarritoEntrada.CurrentRow.Index);

                    //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
                    this.entrada.movimientos.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {

                }


            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
