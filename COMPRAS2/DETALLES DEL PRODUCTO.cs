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
    public partial class DETALLES_DEL_PRODUCTO : Form
    {
        Devices devices;
        public DETALLES_DEL_PRODUCTO(Devices devices)
        {
            InitializeComponent();
            this.devices = devices;           
        }

        public void brnOPCIONES_Click(object sender, EventArgs e)
        {            
            try
            {               
                this.devices = devices;
                Navigator.nextPage(new EDITAR_PRODUCTO(devices));                
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void DETALLES_DEL_PRODUCTO_Load(object sender, EventArgs e)
        {           
            this.lblDProducto.Text = devices.producto;
            this.lblDCompra.Text = devices.compra;
            this.lblDCodigoQR.Text = devices.codigo;
            this.lblDMarca.Text = devices.marca;
            this.lblDModelo.Text = devices.modelo;
            this.lblDCosto.Text = devices.costo.ToString();
            this.lblDOrigen.Text = devices.origen;
            this.lblDFecha.Text = devices.fechaAlta.ToString();
            this.lblDLugar.Text = devices.Lugar_Actual;
            this.lblDEstatus.Text = devices.StatusActual;
            this.lblDDescompostura.Text = devices.descompostura;
            this.lblDProvedor.Text = devices.proveedor;
            this.lblDCantidad.Text = devices.cantidad_de_productos.ToString();
            this.lblDAccesorio.Text = devices.accesorios;
            this.lblObservaciones.Text = devices.observaciones;
            this.lblSerie.Text = devices.serie;
        }

        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea eliminar a este producto?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EliminarProducto();
            }
                       
        }

        private async void EliminarProducto()
        {
                       
            Devices devicesUpdate;
            devicesUpdate = new Devices();

            devicesUpdate.id = devices.id;
            devicesUpdate.statusId = 2;

            
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
                Devices USERS = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                MessageBox.Show("PRODUCTO ELIMINADO");
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
