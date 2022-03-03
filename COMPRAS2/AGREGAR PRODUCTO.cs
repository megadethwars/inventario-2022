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
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace COMPRAS2
{
    public partial class AGREGAR_PRODUCTO : Form
    {
        public AGREGAR_PRODUCTO()
        {
            InitializeComponent();
        }

        private void AGREGAR_PRODUCTO_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async Task<int> Auth()
        {
            try
            {
                int cantidad = 0;
                Int32 costo = 0;
                if (txtProducto.Text == "")
                {
                    MessageBox.Show("campo de producto vacio");
                    return 1;
                }

                if (txtMarca.Text == "")
                {
                    MessageBox.Show("campo de marca vacio");
                    return 1;
                }
                if (txtModelo.Text == "")
                {
                    MessageBox.Show("campo de modelo vacio");
                    return 1;
                }

                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("campo de cantidad vacio");

                    return 1;
                }

                try
                {
                    cantidad = int.Parse(txtCantidad.Text);
                }
                catch {
                    MessageBox.Show("La cantidad no es numerica");
                    return 1;
                }

                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("campo de codigo vacio");
                    return 1;
                }


                if (txtSerie.Text == "")
                {
                    MessageBox.Show("campo de serie vacio");
                    return 1;
                }

                if (txtCosto.Text != "")
                {
                    try
                    {
                        costo = Int32.Parse(txtCosto.Text);
                    }
                    catch
                    {
                        MessageBox.Show("El costo no es numerico");
                        return 1;
                    }
                  
                    
                }

                Devices product = new Devices();
                product.producto = txtProducto.Text;
                product.marca = txtMarca.Text;
                product.modelo = txtModelo.Text;
                product.cantidad = cantidad;
                product.compra = txtCompra.Text;
                product.descompostura = txtDescompostura.Text;
                product.codigo = txtCodigo.Text;
                product.proveedor = txtProvedor.Text;
                product.costo = (int)costo;
                product.observaciones = txtObservaciones.Text;

                product.statusId = 1;
                product.lugarId = 1;




                string json = JsonConvert.SerializeObject(product,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "dispositivos";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);


                if (statusmessage.statuscode == 409)
                {
                    MessageBox.Show("error en el servicio, posiblemente el producto ya exista");
                    return 2;
                }

                else if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("error en el servicio");
                    return 2;
                }
                else if (statusmessage.statuscode == 201)
                {
                    //var auth = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                    List<Devices> devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);
                    MessageBox.Show("PRODUCTO AGREGADO CORRECTAMENTE");
                    return 0;
                }
                else if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("error en el servicio, NO encontrado");

                    return 2;
                }
                else
                {
                    return 2;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo");
                return 10;
            }

        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            int status = await Auth();
        }
    }
}
