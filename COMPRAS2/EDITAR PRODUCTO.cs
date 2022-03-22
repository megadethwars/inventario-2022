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
        Devices devices;
        int id = 0;
        public EDITAR_PRODUCTO(Devices devices)
        {
            InitializeComponent();
            this.devices = devices;
            listaEstatus = new List<Tuple<int, string>>();
            id = devices.Id;
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
            this.txtOrigen.Text = devices.Origen;
            this.txtLugar.Text = devices.Lugar_Actual;
            this.txtDescompostura.Text = devices.descompostura;
            this.txtProvedor.Text = devices.proveedor;
            this.txtCantidad.Text = devices.cantidad.ToString();
            this.txtFoto.Text = devices.Foto;

            int status = await Estatus();
            this.cbEstatus.Text = devices.StatusActual;
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


                var roles = JsonConvert.DeserializeObject<List<StatusDevices>>(statusmessage.data);


                for (int x = 0; x < roles.Count; x++)
                {

                    listaEstatus.Add(Tuple.Create<Int32, String>(roles[x].id, roles[x].descripcion));
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private async void Editar()
        {
            int costo = 0;
            int idEstatus = 0;
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

            devicesUpdate.Origen = txtOrigen.Text;
            devicesUpdate.Lugar_Actual = txtLugar.Text;

            if (cbEstatus.SelectedItem != null)
            {
                var idEstatustuple = (Tuple<int, string>)cbEstatus.SelectedItem;
                idEstatus = idEstatustuple.Item1;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun estatus");
                return;
            }
            devicesUpdate.statusId = idEstatus;

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

            devicesUpdate.Id = id;


            string json = JsonConvert.SerializeObject(devicesUpdate,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "usuarios";
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
            else if (statusmessage.statuscode == 201)
            {
                //var auth = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                List<User> USERS = JsonConvert.DeserializeObject<List<User>>(statusmessage.data);
                MessageBox.Show("EMPLEADO AGREGADO CORRECTAMENTE");
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
