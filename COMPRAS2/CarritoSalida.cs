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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace COMPRAS2
{
    public partial class CarritoSalida : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblCarritoDeSalida.Font = new Font(ff, 26, fontStyle);       
        }

        private void CargoPrivateFontCollection()
        {
            // CREO EL BYTE[] Y TOMO SU LONGITUD
            byte[] fontArray = COMPRAS2.Properties.Resources.Knockout_48;
            int dataLength = COMPRAS2.Properties.Resources.Knockout_48.Length;

            // ASIGNO MEMORIA Y COPIO BYTE[] EN LA DIRECCION
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASO LA FUENTE A LA PRIVATEFONTCOLLECTION
            pfc.AddMemoryFont(ptrData, dataLength);

            //LIBERO LA MEMORIA "UNSAFE"
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }

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
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            dgvCarritoSalida.Columns.Add("Codigo", "Codigo");
            dgvCarritoSalida.Columns.Add("Producto", "Producto");
            dgvCarritoSalida.Columns.Add("Cantidad", "Cantidad");
            dgvCarritoSalida.Columns.Add("Reporte", "Reporte");

            for (int x = 0; x < movimientos.Count; x++)
            {
                Devices producto = movimientos[x].dispositivo;
                movimientos[x].dispositivo_Actual = producto.producto;               
                movimientos[x].codigo_Actual = producto.codigo;
                string[] row = new string[] { movimientos[x].codigo_Actual, movimientos[x].dispositivo_Actual, movimientos[x].cantidad_Actual.ToString(), movimientos[x].comentarios };
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
            var division = (dgvCarritoSalida.Size.Width / 15);
            button3.Location = dgvCarritoSalida.Location;
            this.button3.Location = new Point(this.button3.Location.X + division - 250, this.button3.Location.Y - 110);
            this.button4.Location = new Point(this.dgvCarritoSalida.Location.X + (division * 2) - 220, this.button3.Location.Y);
            this.button1.Location = new Point(this.dgvCarritoSalida.Location.X + (division * 4) - 160, this.button3.Location.Y);
            this.button2.Location = new Point(this.dgvCarritoSalida.Location.X + (division * 5) - 110, this.button3.Location.Y);

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

        private void button1_Click(object sender, EventArgs e)
        {
            //ASCENDENTE
            this.movimientos.Sort((s1, s2) => s1.dispositivo_Actual.CompareTo(s2.dispositivo_Actual));
            dgvCarritoSalida.Rows.Clear();
            foreach (Movimientos x in movimientos)
             {
                string[] row = new string[] { x.codigo_Actual, x.dispositivo_Actual };
                dgvCarritoSalida.Rows.Add(row);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //descendente
            this.movimientos.Sort((s1, s2) => s2.dispositivo_Actual.CompareTo(s1.dispositivo_Actual));
            dgvCarritoSalida.Rows.Clear();
            foreach (Movimientos x in movimientos)
            {
                string[] row = new string[] { x.codigo_Actual, x.dispositivo_Actual };
                dgvCarritoSalida.Rows.Add(row);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.movimientos.Sort((s1, s2) => s2.codigo_Actual.CompareTo(s1.codigo_Actual));
            dgvCarritoSalida.Rows.Clear();
            foreach (Movimientos x in movimientos)
            {
                string[] row = new string[] { x.codigo_Actual, x.dispositivo_Actual };
                dgvCarritoSalida.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.movimientos.Sort((s1, s2) => s1.codigo_Actual.CompareTo(s2.codigo_Actual));
            dgvCarritoSalida.Rows.Clear();
            foreach (Movimientos x in movimientos)
            {
                string[] row = new string[] { x.codigo_Actual, x.dispositivo_Actual };
                dgvCarritoSalida.Rows.Add(row);
            }
        }
    }
}
