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
        public SALIDA salida;
        public List<Movimientos> movimientos;
        DataGridViewButtonColumn btnclm;
        public CarritoSalida(SALIDA salida)
        {
            InitializeComponent();
            this.salida = salida;

            this.movimientos = this.salida.movimientos;
        }
        

        private void CarritoSalida_Load(object sender, EventArgs e)
        {

            dgvCarritoSalida.Columns.Add("Codigo", "Codigo");
            dgvCarritoSalida.Columns.Add("Producto", "Producto");
            dgvCarritoSalida.Columns.Add("Cantidad", "Cantidad");
            //dgvCarritoSalida.Columns[0].Name = "Codigo";
            //dgvCarritoSalida.Columns[1].Name = "Producto";
            //dgvCarritoSalida.Columns[2].Name = "Cantidad";

            for (int x = 0; x < movimientos.Count; x++)
            {
                Devices producto = movimientos[x].dispositivo;
                movimientos[x].dispositivo_Actual = producto.producto;
                movimientos[x].cantidad_Actual = producto.cantidad;
                movimientos[x].codigo_Actual = producto.codigo;
                string[] row = new string[] { movimientos[x].codigo_Actual, movimientos[x].dispositivo_Actual, movimientos[x].cantidad_Actual.ToString() };
                dgvCarritoSalida.Rows.Add(row);
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
            this.dgvCarritoSalida.Columns.Add(btnclm);

         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void dgvCarritoSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if(dgvCarritoSalida.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if(MessageBox.Show("Seguro que quieres eliminar este producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //dgvCarritoSalida.Rows[e.RowIndex].Dispose();
                }
            }*/
        }

        private void dgvCarritoSalida_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*if (dgvCarritoSalida.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if (MessageBox.Show("Seguro que quieres eliminar este producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //dgvCarritoSalida.Rows[e.RowIndex].Dispose();
                }
            }*/

            /*if(e.ColumnIndex >= 0 && this.dgvCarritoSalida.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >=0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton = this.dgvCarritoSalida.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                this.dgvCarritoSalida.Rows[e.RowIndex].Height = "Eliminar";
            }*/
        }

        private void dgvCarritoSalida_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvCarritoSalida.Columns.IndexOf(btnclm))
            {
                try
                {
                    //DataGridViewRow row = dgvCarritoSalida.Rows[e.RowIndex];
                    dgvCarritoSalida.Rows.RemoveAt(dgvCarritoSalida.CurrentRow.Index);

                    //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
                    this.salida.movimientos.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {

                }


            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.salida.movimientos.Count == 0) {
                MessageBox.Show("No hay productos en el carrito");
                return;
            }

            Navigator.nextPage(new ConfirmarSalida(this));
        }
    }
}
