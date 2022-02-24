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

            //List <List<Lugares>>(statusmessage.data);
            List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);

            dgvLugares.DataSource = devices;
        }
    }
}
