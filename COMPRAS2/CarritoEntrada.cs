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
    public partial class CarritoEntrada : Form
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

        public List<Movimientos> movimientos;
        DataGridViewButtonColumn btnclm;
        public ENTRADA entrada;
        public CarritoEntrada(ENTRADA entrada)
        {
            InitializeComponent();
            this.entrada = entrada;
            this.movimientos = this.entrada.movimientos;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void CarritoEntrada_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

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


            var division = (dgvCarritoEntrada.Size.Width / 12);
            button3.Location = dgvCarritoEntrada.Location;
            this.button3.Location = new Point(this.button3.Location.X + division - 30,this.button3.Location.Y + 45);
            this.button4.Location = new Point(this.dgvCarritoEntrada.Location.X + (division * 2), this.button3.Location.Y);
            this.button1.Location = new Point(this.dgvCarritoEntrada.Location.X + (division * 4) - 30, this.button3.Location.Y);
            this.button2.Location = new Point(this.dgvCarritoEntrada.Location.X + (division * 5), this.button3.Location.Y);
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
            if (this.entrada.movimientos.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito");
                return;
            }

            Navigator.nextPage(new ConfirmarEntrada(this));
        }
    }
}
