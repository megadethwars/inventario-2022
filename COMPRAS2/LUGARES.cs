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
    public partial class LUGARES : Form
    {
        string url = "https://avsinventoryswagger.azurewebsites.net/api/v1/";

        public LUGARES()
        {
            InitializeComponent();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async void LUGARES_Load(object sender, EventArgs e)
        {
            var url = HttpMethods.url + "lugares";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }
            
            List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);

            dgvLugares.DataSource = devices;
            this.dgvLugares.Columns["fechaAlta"].Visible = false;
            this.dgvLugares.Columns["fechaUltimaModificacion"].Visible = false;
            this.dgvLugares.Columns["id"].Visible = false;
            this.dgvLugares.Columns["activo"].Visible = false;
        }

        private async Task<int> Auth()
        {
            try
            {
                Lugares lugarnew = new Lugares();
                lugarnew.lugar = txtLugarDeseado.Text;

                string json = JsonConvert.SerializeObject(lugarnew,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "lugares";
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
                    List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);
                    MessageBox.Show("PRODUCTO AGREGADO CORRECTAMENTE");
                    Navigator.backPage(this.Name, this);
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

        private void txtLugarDeseado_Click(object sender, EventArgs e)
        {
            txtLugarDeseado.Clear();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            int status = await Auth();           
        }
    }
}
