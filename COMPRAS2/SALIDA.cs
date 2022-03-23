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
    public partial class SALIDA : Form
    {
        
        public SALIDA()
        {
            InitializeComponent();

            
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


            /*
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                //busqueda();
            }
            */
            
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
                List<Devices> devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                this.lbNombre.Text = devices[0].producto;
                this.lbOrigen.Text = devices[0].Origen;
                this.lbSerie.Text = "N/A";
                this.lbCantitad.Text = devices[0].cantidad.ToString();
                this.lbMarca.Text = devices[0].marca;
                this.lbdesc.Text = devices[0].descompostura;

            }

        }

        private void Agregar() { 
        
        }
        private void btAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
