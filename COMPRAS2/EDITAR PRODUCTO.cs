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
    public partial class EDITAR_PRODUCTO : Form
    {
        List<Tuple<Int32, String>> listaEstatus;
        List<Tuple<Int32, String>> listaLugares;

        Devices devices;
        int id = 0;
        public EDITAR_PRODUCTO(Devices devices)
        {
            InitializeComponent();
            this.devices = devices;
            listaEstatus = new List<Tuple<int, string>>();
            listaLugares = new List<Tuple<int, string>>();
            id = devices.id;
        }

        public EDITAR_PRODUCTO()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);

        }

        private async void EDITAR_PRODUCTO_Load(object sender, EventArgs e)
        {
            this.txtProducto.Text = devices.producto;
            this.txtCodigoQR.Text = devices.codigo;
            this.txtCompra.Text = devices.compra;
            this.txtMarca.Text = devices.marca;
            this.txtModelo.Text = devices.modelo;
            this.txtCosto.Text = devices.costo.ToString();
            this.txtOrigen.Text = devices.origen;
            this.txtDescompostura.Text = devices.descompostura;
            this.txtProvedor.Text = devices.proveedor;
            this.txtCantidad.Text = devices.cantidad.ToString();
            this.txtFoto.Text = devices.foto;

            int status = await Estatus();
            int lugars = await Lugares();
            this.cbEstatus.Text = devices.StatusActual;
            this.cbLugares.Text = devices.Lugar_Actual;
        }

        private async Task<int> Estatus()
        {
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private async void Editar()
        {
            int costo = 0;
            int idEstatus = 0;
            int idLugares = 0;
            int cantidad = 0;

            Devices devicesUpdate;
            devicesUpdate = new Devices();

            devicesUpdate.producto = txtProducto.Text;
            devicesUpdate.codigo = txtCodigoQR.Text;
            devicesUpdate.compra = txtCompra.Text;
            devicesUpdate.marca = txtMarca.Text;
            devicesUpdate.modelo = txtModelo.Text;

            try
            {
                costo = int.Parse(txtCosto.Text);
            }
            catch
            {
                MessageBox.Show("La cantidad no es numerica");
                return;
            }
            devicesUpdate.costo = costo;

            devicesUpdate.origen = txtOrigen.Text;

            //devicesUpdate.Lugar_Actual = txtLugar.Text;
            
            if (cbLugares.SelectedItem != null)
            {
                var idLugarestuple = (Tuple<int, string>)cbEstatus.SelectedItem;
                idLugares = idLugarestuple.Item1;
                devicesUpdate.lugarId = idLugares;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun estatus");
                return;
            }
            devicesUpdate.lugarId = idLugares;

            if (cbEstatus.SelectedItem != null)
            {
                var idEstatustuple = (Tuple<int, string>)cbEstatus.SelectedItem;
                idEstatus = idEstatustuple.Item1;
                devicesUpdate.statusId = idEstatus;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun estatus");
                return;
            }            

            devicesUpdate.descompostura = txtDescompostura.Text;
            devicesUpdate.proveedor = txtProvedor.Text;

            try
            {
                cantidad = int.Parse(txtCantidad.Text);
            }
            catch
            {
                MessageBox.Show("La cantidad no es numerica");
                return;
            }
            devicesUpdate.cantidad = cantidad;

            devicesUpdate.id = id;


            string json = JsonConvert.SerializeObject(devicesUpdate,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos";
            StatusMessage statusmessage = await HttpMethods.put(url, json);

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("error en el servicio, " + statusmessage.message);
                return;
            }

            else if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("error en el servicio");
                return;
            }
            else if (statusmessage.statuscode == 200)
            {
                //var auth = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                Devices USERS = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                MessageBox.Show("PRODUCTO ACTUALIZADO CORRECTAMENTE");
                Navigator.backPage(this.Name, this);
                return;
            }
            else if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("error en el servicio, NO encontrado");

                return;
            }
            else
            {
                MessageBox.Show("Bad request, algunos campos faltantes");
                return;
            }

            Navigator.backPage(this.Name, this);
        }
    }
}
