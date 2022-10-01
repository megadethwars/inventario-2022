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
    public partial class BUSQUEDA_AVANZADA : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        QueryDevice devicequery;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblBusquedaAvanzada.Font = new Font(ff, 26, fontStyle);
            this.lblProducto.Font = new Font(ff, 20, fontStyle);
            this.lblCodigo.Font = new Font(ff, 20, fontStyle);
            this.lblMarca.Font = new Font(ff, 20, fontStyle);
            this.lblModelo.Font = new Font(ff, 20, fontStyle);
            this.lblSerie.Font = new Font(ff, 20, fontStyle);
            this.lblLugares.Font = new Font(ff, 20, fontStyle);
            this.lblEstatus.Font = new Font(ff, 20, fontStyle);
            this.btnLimpiar.Font = new Font(ff, 20, fontStyle);
            
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
            dgvInventario.Scroll += new System.Windows.Forms.ScrollEventHandler(DataGridView1_Scroll);
        }

        List<Tuple<Int32, String>> listaEstatus;
        List<Tuple<Int32, String>> listaLugares;
        int lugarid = 0;
        int statusid = 0;
        int offssetpage = 25;
        int page = 1;
        bool isFiltering = false;
        List<Devices> devices;

        private async void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue >= (dgvInventario.Rows.Count - offssetpage))
            {
                try
                {
                    //obtener siguiente linea
                    page = page + 1;
                    string url = "";
                    string json = JsonConvert.SerializeObject(devicequery,
                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });

                    url = HttpMethods.url + "dispositivos/query?offset=" + page.ToString() + "&limit=30";


                    StatusMessage statusmessage = await HttpMethods.Post(url, json);
                    devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);
                    if (devices.Count == 0)
                    {
                        return;
                    }
                    int i = 0;
                    foreach (Devices device in devices)
                    {
                        Lugares lugar = device.lugar;
                        devices[i].Lugar_Actual = lugar.lugar;

                        StatusDevices status = device.status;
                        devices[i].StatusActual = status.descripcion;
                        i++;
                    }

                    for (int x = 0; x < devices.Count; x++)
                    {
                        Devices inv = devices[x];
                        devices[x].producto = inv.producto;
                        devices[x].codigo = inv.codigo;
                        devices[x].Lugar_Actual = inv.Lugar_Actual;
                        devices[x].marca = inv.marca;
                        devices[x].modelo = inv.modelo;
                        devices[x].StatusActual = inv.StatusActual;

                        string[] row = new string[] { devices[x].producto, devices[x].codigo,
                    devices[x].Lugar_Actual.ToString(), devices[x].marca, devices[x].modelo,
                    devices[x].StatusActual};
                        dgvInventario.Rows.Add(row);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("ocurrio un error en la consulta");
                }
                
            }
        }

        public BUSQUEDA_AVANZADA(Devices devices)
        {
            InitializeComponent();
            listaEstatus = new List<Tuple<int, string>>();
            listaLugares = new List<Tuple<int, string>>();
            devicequery = new QueryDevice();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async Task<int> Estatus()
        {
            int idLugares = 0;
            try
            {
                var url = HttpMethods.url + "statusDevices";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno del servidor");
                    return 2;
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("Estatus no encontrados");
                    return 2;
                }

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }

                var estatus = JsonConvert.DeserializeObject<List<StatusDevices>>(statusmessage.data);

                listaEstatus.Add(Tuple.Create<Int32, String>(0, "ninguno"));

                for (int x = 0; x < estatus.Count; x++)
                {
                    listaEstatus.Add(Tuple.Create<Int32, String>(estatus[x].id, estatus[x].descripcion));
                }
                cbEstatus.DataSource = listaEstatus;
                cbEstatus.DisplayMember = "Item2";
                cbEstatus.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async Task<int> Lugares()
        {
            try
            {
                var url = HttpMethods.url + "lugares";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno del servidor");
                    return 2;
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("Estatus no encontrados");
                    return 2;
                }

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }

                var lugares = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);

                listaLugares.Add(Tuple.Create<Int32, String>(0, "ninguno"));

                for (int x = 0; x < lugares.Count; x++)
                {
                    listaLugares.Add(Tuple.Create<Int32, String>(lugares[x].id, lugares[x].lugar));
                }
                cbLugares.DataSource = listaLugares;
                cbLugares.DisplayMember = "Item2";
                cbLugares.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async void BUSQUEDA_AVANZADA_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            int status = await Estatus();
            int lugars = await Lugares();
            this.cbEstatus.Text = null;
            this.cbLugares.SelectedItem = null;
        }
        
        public async void busqueda()
        {
            int idLugares = 0;
            int idEstatus = 0;
            page = 1;
            
            if (txtProducto.Text != "")
            {
                devicequery.producto = txtProducto.Text;              
            }

            if (txtCodigo.Text != "")
            {
                devicequery.codigo = txtCodigo.Text;
            }

            if (txtMarca.Text != "") 
            {
                devicequery.marca = txtMarca.Text;
            }

            if (txtModelo.Text != "")
            {
                devicequery.modelo = txtModelo.Text;
            }

            if (txtSerie.Text != "")
            {
                devicequery.serie = txtSerie.Text;
            }

            if (cbLugares.SelectedItem != null)
            {
                var idLugarestuple = (Tuple<int, string>)cbLugares.SelectedItem;
                idLugares = idLugarestuple.Item1;
                if(idLugares != 0)
                {
                    devicequery.lugarId = idLugares;
                }               
            }         

            if (cbEstatus.SelectedItem != null)
            {
                var idEstatustuple = (Tuple<int, string>)cbEstatus.SelectedItem;
                idEstatus = idEstatustuple.Item1;
                if (idEstatus != 0)
                {
                    devicequery.statusId = idEstatus;
                }
            }           

            string json = JsonConvert.SerializeObject(devicequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos/query?limit=30&offset=1";
            StatusMessage statusmessage = await HttpMethods.Post(url, json);

            if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("Error interno en el servidor");
            }

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("Ocurrio un conflicto");
            }

            if (statusmessage.statuscode == 400)
            {
                MessageBox.Show("No hay campos seleccionados a consultar");                
            }

            if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("recurso NO encontrado");
            }

            if (statusmessage.statuscode == 200)
            {
                dgvInventario.Columns.Clear();
                devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                if(devices.Count == 0)
                {                
                     MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                     dgvInventario.DataSource = null;
                    return;
                }

                for (int x = 0; x < devices.Count; x++)
                {
                    Lugares lugar = devices[x].lugar;
                    devices[x].Lugar_Actual = lugar.lugar;

                    StatusDevices status = devices[x].status;
                    devices[x].StatusActual = status.descripcion;
                }

                dgvInventario.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvInventario.Columns.Add("ID", "ID");
                dgvInventario.Columns.Add("LUGAR", "LUGAR");
                dgvInventario.Columns.Add("MARCA", "MARCA");
                dgvInventario.Columns.Add("MODELO", "MODELO");
                dgvInventario.Columns.Add("ESTATUS", "ESTATUS");

                for (int x = 0; x < devices.Count; x++)
                {
                    Devices inv = devices[x];
                    devices[x].producto = inv.producto;
                    devices[x].codigo = inv.codigo;
                    devices[x].Lugar_Actual = inv.Lugar_Actual;
                    devices[x].marca = inv.marca;
                    devices[x].modelo = inv.modelo;
                    devices[x].StatusActual = inv.StatusActual;

                    string[] row = new string[] { devices[x].producto, devices[x].codigo,
                    devices[x].Lugar_Actual.ToString(),
                    devices[x].marca, devices[x].modelo, devices[x].StatusActual};
                    dgvInventario.Rows.Add(row);
                }                               
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvInventario.Rows.Clear();
            dgvInventario.Columns.Clear();
            dgvInventario.DataSource = null;
            this.txtProducto.Text = null;
            this.txtCodigo.Text = null;
            this.txtMarca.Text = null;
            this.txtModelo.Text = null;
            this.txtSerie.Text = null;
            this.cbEstatus.Text = null;
            this.cbLugares.SelectedItem = null;
            devicequery = new QueryDevice();
            page = 1;
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvInventario.Rows[e.RowIndex];
                DataGridViewCellCollection columns = cell.Cells;

                var index = columns[1];
                var codigo = index.FormattedValue;
                //var datafind = devices.Find(x => x.codigo.Contains((string)codigo));

                Navigator.nextPage(new DETALLES_DEL_PRODUCTO((string)codigo));

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
