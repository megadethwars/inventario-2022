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

namespace COMPRAS2
{
    public partial class BUSQUEDA_AVANZADA__HISTORIAL : Form
    {
        List<Tuple<Int32, String>> listaEstatus;
        List<Tuple<Int32, String>> listaLugares;
        List<Tuple<Int32, String>> listaTipoMov;
        List<Devices> devices;

        int iddevice = 0;

        public BUSQUEDA_AVANZADA__HISTORIAL()
        {
            InitializeComponent();
            listaEstatus = new List<Tuple<int, string>>();
            listaLugares = new List<Tuple<int, string>>();
            listaTipoMov = new List<Tuple<int, string>>();
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
            int tipomov = await TipoMov();
            int status = await Estatus();
            int lugars = await Lugares();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvBusquedaHistorial.DataSource = null;
            this.txtMovimiento.Text = null;
            this.txtCodigo.Text = null;
        }

        private async void busqueda() 
        {
            int idtipomov = 0;
            int idstatus = 0;
            int idlugars = 0;

            QueryDevice histquery = new QueryDevice();

            if (txtCodigo.Text != "")
            {
                histquery.codigo = txtCodigo.Text;
            }

            if (txtMovimiento.Text != "")
            {
                histquery.idMov = txtMovimiento.Text;
            }
            /*
            if (cbLugares.SelectedItem != null)
            {
                var idLugarestuple = (Tuple<int, string>)cbLugares.SelectedItem;
                idLugares = idLugarestuple.Item1;
                if (idLugares != 0)
                {
                    devicequery.lugarId = idLugares;
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun lugar");
                return;
            }*/

            if (txtCodigo.Text != "") {

                QueryDevice querydevice = new QueryDevice();

                querydevice.codigo = txtCodigo.Text;

                string json = JsonConvert.SerializeObject(querydevice,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "dispositivos/query";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno en el servidor");
                    return;
                }

                if (statusmessage.statuscode == 409)
                {
                    MessageBox.Show("Ocurrio un conflicto en busqueda de productos");
                    return;
                }

                if (statusmessage.statuscode == 400)
                {
                    MessageBox.Show("No hay campos seleccionados a consultar");
                    return;
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("producto NO encontrado");
                    return;
                }

                if (statusmessage.statuscode == 200)
                {
                    devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                    if (devices.Count == 0)
                    {
                        MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                        dgvBusquedaHistorial.DataSource = null;
                        return;
                    }


                    iddevice = devices[0].id;

                  

                }
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            busqueda();
        }
    }
}
