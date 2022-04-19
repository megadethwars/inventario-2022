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
    public partial class BUSQUEDA_AVANZADA_EMPLEADO : Form
    {
        List<Tuple<Int32, String>> listaEstado;
        List<Tuple<Int32, String>> listaRoles;

        public BUSQUEDA_AVANZADA_EMPLEADO(Devices devices)
        {
            InitializeComponent();
            listaEstado = new List<Tuple<int, string>>();
            listaRoles = new List<Tuple<int, string>>();
        }

        private async Task<int> Estado()
        {
            try
            {
                var url = HttpMethods.url + "statusUsuarios";
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

                var estatus = JsonConvert.DeserializeObject<List<StatusUser>>(statusmessage.data);

                for (int x = 0; x < estatus.Count; x++)
                {
                    listaEstado.Add(Tuple.Create<Int32, String>(estatus[x].id, estatus[x].descripcion));
                }
                cbEstado.DataSource = listaEstado;
                cbEstado.DisplayMember = "Item2";
                cbEstado.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }
        
        private async Task<int> Roles()
        {
            try
            {
                var url = HttpMethods.url + "roles";
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

                var lugares = JsonConvert.DeserializeObject<List<Rol>>(statusmessage.data);

                for (int x = 0; x < lugares.Count; x++)
                {
                    listaRoles.Add(Tuple.Create<Int32, String>(lugares[x].id, lugares[x].nombre));
                }
                cbRoles.DataSource = listaRoles;
                cbRoles.DisplayMember = "Item2";
                cbRoles.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async void BUSQUEDA_AVANZADA_EMPLEADO_Load(object sender, EventArgs e)
        {
            int status = await Estado();
            int roles = await Roles();
            this.cbEstado.Text = null;
            this.cbRoles.Text = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = null;
            this.txtNombre.Text = null;
            this.txtCorreo.Text = null;
            this.txtApellidoPaterno.Text = null;
            this.txtApellidoMaterno.Text = null;
            this.txtTelefono.Text = null;
            this.txtUsuario = null;
            this.cbEstado.Text = null;
            this.cbRoles.Text = null;
        }
        /*
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
                if (idLugares != 0)
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

                if (devices.Count == 0)
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
        }*/
    }
}
