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

        private void txtLugarDeseado_Click(object sender, EventArgs e)
        {
            txtLugarDeseado.Clear();
        }
    }
}
