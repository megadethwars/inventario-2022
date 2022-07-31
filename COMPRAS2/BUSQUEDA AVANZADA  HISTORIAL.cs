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
    public partial class BUSQUEDA_AVANZADA__HISTORIAL : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblHISTORIAL.Font = new Font(ff, 26, fontStyle);
            this.lblLugares.Font = new Font(ff, 20, fontStyle);
            this.lblEstatus.Font = new Font(ff, 20, fontStyle);
            this.label1.Font = new Font(ff, 20, fontStyle);
            this.lblCodigo.Font = new Font(ff, 20, fontStyle);
            this.label2.Font = new Font(ff, 20, fontStyle);
            this.cbhHistorial.Font = new Font(ff, 20, fontStyle);
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
        }

        List<Tuple<Int32, String>> listaUsuarios;
        List<Tuple<Int32, String>> listaLugares;
        List<Tuple<Int32, String>> listaTipoMov;
        List<Movimientos> historial;
        List<Devices> devices;

        int iddevice = 0;

        public BUSQUEDA_AVANZADA__HISTORIAL()
        {
            InitializeComponent();
            dtpHistorial.CustomFormat = "yyyy-MM-dd";
            listaUsuarios = new List<Tuple<int, string>>();
            listaLugares = new List<Tuple<int, string>>();
            listaTipoMov = new List<Tuple<int, string>>();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }
        
        private async Task<int> Usuarios()
        {
            int idUsuarios = 0;
            try
            {
                var url = HttpMethods.url + "usuarios";
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

                var estatus = JsonConvert.DeserializeObject<List<User>>(statusmessage.data);

                listaUsuarios.Add(Tuple.Create<Int32, String>(0, "ninguno"));

                for (int x = 0; x < estatus.Count; x++)
                {
                    listaUsuarios.Add(Tuple.Create<Int32, String>(estatus[x].id, estatus[x].nombre));
                }
                cbUsuario.DataSource = listaUsuarios;
                cbUsuario.DisplayMember = "Item2";
                cbUsuario.ValueMember = "Item1";

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

        private async Task<int> TipoMov()
        {
            try
            {
                var url = HttpMethods.url + "tipomoves";
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

                var tipos = JsonConvert.DeserializeObject<List<TipoMovimiento>>(statusmessage.data);

                listaTipoMov.Add(Tuple.Create<Int32, String>(0, "ninguno"));

                for (int x = 0; x < tipos.Count; x++)
                {
                    listaTipoMov.Add(Tuple.Create<Int32, String>(tipos[x].id, tipos[x].tipo));
                }
                cbMovimiento.DataSource = listaTipoMov;
                cbMovimiento.DisplayMember = "Item2";
                cbMovimiento.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async void BUSQUEDA_AVANZADA__HISTORIAL_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            int tipomov = await TipoMov();
            int users = await Usuarios();
            int lugars = await Lugares();
            this.cbLugares.Text = null;
            this.cbUsuario.Text = null;
            this.cbMovimiento.Text = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvBusquedaHistorial.Rows.Clear();
            dgvBusquedaHistorial.Columns.Clear();
            dgvBusquedaHistorial.DataSource = null;
            this.txtCodigo.Text = null;
            this.cbLugares.Text = null;
            this.cbUsuario.Text = null;
            this.cbMovimiento.Text = null;
        }

        private async void busqueda() 
        {
            dgvBusquedaHistorial.Columns.Clear();
            dgvBusquedaHistorial.Rows.Clear();
            dgvBusquedaHistorial.DataSource = null;
            int idtipomov = 0;
            int idUsers = 0;
            int idLugares = 0;

            QueryMovimientos hist = new QueryMovimientos();

            QueryDevice devicequery = new QueryDevice();

            if (txtCodigo.Text != "")
            {
                devicequery.codigo = txtCodigo.Text;              
            }

            if (cbhHistorial.Checked == true)
            {
                dtpHistorial.Enabled = true;
                if (cbhHistorial.Text != "")
                {
                    hist.fechaAltaRangoInicio = dtpHistorial.Text;
                }
            }
            else
            {
                dtpHistorial.Enabled = false;

            }

            string jsonD = JsonConvert.SerializeObject(devicequery,
            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var urlD = HttpMethods.url + "dispositivos/query";
            StatusMessage statusmessageD = await HttpMethods.Post(urlD, jsonD);

            if (statusmessageD.statuscode == 500)
            {
                MessageBox.Show("Error interno en el servidor");
                return;
            }

            if (statusmessageD.statuscode == 409)
            {
                MessageBox.Show("Ocurrio un conflicto en busqueda de productos");
                return;
            }

            if (statusmessageD.statuscode == 400)
            {/*
                MessageBox.Show("No hay campos seleccionados a consultar");
                return;*/
            }

            if (statusmessageD.statuscode == 404)
            {
                MessageBox.Show("producto NO encontrado");
                return;
            }

            if (statusmessageD.statuscode == 200)
            {                
                devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessageD.data);

                if (devices.Count == 0)
                {
                    MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                    dgvBusquedaHistorial.DataSource = null;
                    return;
                }
                iddevice = devices[0].id;

                hist.dispositivoId = iddevice;
            }

            if (cbUsuario.SelectedItem != null)
            {
                var idUserstuple = (Tuple<int, string>)cbUsuario.SelectedItem;
                idUsers = idUserstuple.Item1;
                if (idUsers != 0)
                {
                    hist.usuarioId = idUsers;
                }
            }

            if (cbLugares.SelectedItem != null)
            {
                var idLugarestuple = (Tuple<int, string>)cbLugares.SelectedItem;
                idLugares = idLugarestuple.Item1;
                if (idLugares != 0)
                {
                    hist.LugarId = idLugares;
                }
            }

            if (cbMovimiento.SelectedItem != null)
            {
                var idTipoMovestuple = (Tuple<int, string>)cbMovimiento.SelectedItem;
                idtipomov = idTipoMovestuple.Item1;
                if (idtipomov != 0)
                {
                    hist.tipoMovId = idtipomov;
                }
            }         

            string json = JsonConvert.SerializeObject(hist,
            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "movimientos/query";
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
                 historial = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);
                
                for (int x = 0; x < historial.Count; x++)
                {
                    Devices dispositivo = historial[x].dispositivo;
                    historial[x].dispositivo_Actual = dispositivo.producto;
                    historial[x].codigo_Actual = dispositivo.codigo;

                    Lugares lugar = historial[x].lugar;
                    historial[x].Lugar_Actual = lugar.lugar;

                    User usuario = historial[x].usuario;
                    historial[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + "" + usuario.apellidoMaterno;

                    TipoMovimiento tipoMovimiento = historial[x].tipoMovimiento;
                    historial[x].tipo_Actual = tipoMovimiento.tipo;
                }

                dgvBusquedaHistorial.Columns.Add("FECHA", "FECHA");
                dgvBusquedaHistorial.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvBusquedaHistorial.Columns.Add("ID", "ID");
                dgvBusquedaHistorial.Columns.Add("LUGAR", "LUGAR");
                dgvBusquedaHistorial.Columns.Add("NOMBRE", "NOMBRE");
                dgvBusquedaHistorial.Columns.Add("TIPO", "TIPO");

                for (int x = 0; x < historial.Count; x++)
                {
                    Movimientos mov = historial[x];
                    historial[x].fechaAlta = mov.fechaAlta;
                    historial[x].dispositivo_Actual = mov.dispositivo_Actual;
                    historial[x].idMovimiento = mov.idMovimiento;
                    historial[x].Lugar_Actual = mov.Lugar_Actual;
                    historial[x].nombre_Actual = mov.nombre_Actual;
                    historial[x].tipo_Actual = mov.tipo_Actual;

                    string[] row = new string[] { historial[x].fechaAlta.ToString(), historial[x].dispositivo_Actual,
                    historial[x].idMovimiento, historial[x].Lugar_Actual, historial[x].nombre_Actual, historial[x].tipo_Actual};
                    dgvBusquedaHistorial.Rows.Add(row);
                }
                //dgvBusquedaHistorial.DataSource = historial;
                //this.dgvBusquedaHistorial.Columns["foto"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["fechaUltimaModificacion"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["foto2"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["dispositivoId"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["usuarioId"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["LugarId"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["comentarios"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["tipoMovId"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["dispositivo"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["usuario"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["tipoMovimiento"].Visible = false;
                //this.dgvBusquedaHistorial.Columns["idMovimiento"].Visible = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private void cbhHistorial_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhHistorial.Checked == true)
            {
                dtpHistorial.Enabled = true;
            }
            else
            {
                dtpHistorial.Enabled = false;

            }
        }

        private void dgvBusquedaHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvBusquedaHistorial.Rows[e.RowIndex];
                DataGridViewCellCollection columns = cell.Cells;
                Movimientos data = (Movimientos)cell.DataBoundItem;
                var index = columns[1];
                var codigo = index.FormattedValue;
                var datafind = historial.Find(x => x.dispositivo_Actual.Contains((string)codigo));

                Navigator.nextPage(new DETALLES_HISTORIAL(datafind));

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
