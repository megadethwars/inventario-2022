using COMPRAS2.modelos;
using COMPRAS2.servicios;
using Newtonsoft.Json;
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
    public partial class SALIDA : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        int count = 0;
        DataGridViewButtonColumn btnclm;
        List<Tuple<Int32, String>> listaLugares;
        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblSALIDA.Font = new Font(ff, 26, fontStyle);
  
            this.btnAgregarCarrito.Font = new Font(ff, 18, fontStyle);
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

        public List<Devices> devices;
        public List<Movimientos> movimientos;
        public SALIDA()
        {
            InitializeComponent();
            devices = new List<Devices>();
            movimientos = new List<Movimientos>();
            listaLugares = new List<Tuple<Int32, String>>();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void CheckEnter(object sender, KeyEventArgs e)
        {        
            if (e.KeyCode == Keys.Enter)
            {
                busqueda();
            }          
        }

        public async void busqueda() {

            //busqueda
            if (txtBUSCADOR.Text == "") {
                MessageBox.Show("Campo de Texto vacio");
                return;          
            }

            QueryDevice devicequery = new QueryDevice();
            devicequery.codigo = txtBUSCADOR.Text;

            string json = JsonConvert.SerializeObject(devicequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos/query";
            StatusMessage statusmessage = await HttpMethods.Post(url,json);

            if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("Error interno en el servidor");
            }

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("Ocurrio un conflicto");
            }

            if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("recurso NO encontrado");
            }

            if (statusmessage.statuscode == 200)
            {
                devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                if (devices.Count == 0)
                {
                    MessageBox.Show("No hay dispositivos en stock, cantidad Insuficiente");
                    return;
                }
                

                Agregar(devices[0]);

            }

        }

        private void Agregar(Devices device) {
            //convert device to movement
            Movimientos movement = new Movimientos();
            movement.usuarioId = CurrentUsers.id;
            movement.dispositivoId = device.id;
            movement.dispositivo = device;                        
            movement.tipoMovId = 1;
            bool deviceExist = movimientos.Any(x => x.dispositivoId == device.id && x.dispositivoId == device.id);
            if (deviceExist) {
                MessageBox.Show("el producto ya existe en la lista");
                return;
            }
            txtBUSCADOR.Text = "";
            count++;
            lbCount.Text = count.ToString();
            lbCount.Text = count.ToString();
            movimientos.Add(movement);
            string[] row = new string[] { device.codigo, device.producto,device.modelo };
            dgvSalida.Rows.Add(row);
        }
        

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (movimientos.Count == 0) {
                MessageBox.Show("No hay productos para realizar una salida");
                return;
            }
            Navigator.nextPage(new CarritoSalida(this));
        }        

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            txtBUSCADOR.Clear();
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private async void SALIDA_LoadAsync(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            dgvSalida.Columns.Add("Codigo", "Codigo");
            dgvSalida.Columns.Add("Producto", "Producto");
            dgvSalida.Columns.Add("modelo", "modelo");
            

            btnclm = new DataGridViewButtonColumn();
            btnclm.Name = "El";
            btnclm.Text = "Eliminar";
            btnclm.HeaderText = "Eliminar";
            btnclm.UseColumnTextForButtonValue = true;
            this.dgvSalida.Columns.Add(btnclm);

           
        }

        private void dgvCarritoSalida_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvSalida.Columns.IndexOf(btnclm))
            {
                try
                {
                    //DataGridViewRow row = dgvCarritoSalida.Rows[e.RowIndex];
                    dgvSalida.Rows.RemoveAt(dgvSalida.CurrentRow.Index);

                    //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
                    this.movimientos.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {

                }


            }
        }

        

        private void dgvSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
