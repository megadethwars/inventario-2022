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
    public partial class BUSQUEDA_AVANZADA : Form
    {
        List<Tuple<Int32, String>> listaEstatus;
        List<Tuple<Int32, String>> listaLugares;
        int lugarid = 0;
        int statusid = 0;
        List<Devices> devices;

        public BUSQUEDA_AVANZADA(Devices devices)
        {
            InitializeComponent();
            listaEstatus = new List<Tuple<int, string>>();
            listaLugares = new List<Tuple<int, string>>();
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
            int status = await Estatus();
            int lugars = await Lugares();
        }

        
        public async void busqueda()
        {
            int idLugares = 0;
            int idEstatus = 0;

            QueryDevice devicequery = new QueryDevice();
            
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
            else
            {
                MessageBox.Show("No se ha seleccionado ningun estatus");
                return;
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
            else
            {
                MessageBox.Show("No se ha seleccionado ningun estatus");
                return;
            }

            string json = JsonConvert.SerializeObject(devicequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos/query";
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
                
                dgvInventario.DataSource = devices;
                
                this.dgvInventario.Columns["lugar"].Visible = false;
                this.dgvInventario.Columns["lugarId"].Visible = false;
                this.dgvInventario.Columns["status"].Visible = false;
                this.dgvInventario.Columns["statusId"].Visible = false;
                this.dgvInventario.Columns["Compra"].Visible = false;
                this.dgvInventario.Columns["Descompostura"].Visible = false;
                this.dgvInventario.Columns["Foto"].Visible = false;
                this.dgvInventario.Columns["IdMov"].Visible = false;
                this.dgvInventario.Columns["Observaciones"].Visible = false;
                this.dgvInventario.Columns["Origen"].Visible = false;
                this.dgvInventario.Columns["Pertenece"].Visible = false;
                this.dgvInventario.Columns["Proveedor"].Visible = false;
                this.dgvInventario.Columns["Costo"].Visible = false;
                this.dgvInventario.Columns["FechaUltimaModificacion"].Visible = false;

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dgvInventario.DataSource = null;
            this.txtProducto.Text = null;
            this.txtCodigo.Text = null;
            this.txtMarca.Text = null;
            this.txtModelo.Text = null;
            this.txtSerie.Text = null;
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvInventario.Rows[e.RowIndex];
                Devices data = (Devices)cell.DataBoundItem;

                Navigator.nextPage(new DETALLES_DEL_PRODUCTO(data));

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
