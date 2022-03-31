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
    public partial class HIST : Form
    {
        public HIST()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnBUSQUEDAAVANZADA_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new BUSQUEDA_AVANZADA__HISTORIAL());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new SALIDA());
        }

        private async void HIST_Load(object sender, EventArgs e)
        {
            var url = HttpMethods.url + "movimientos";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }

            List<Movimientos> devices = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);
            dgvHistorial.DataSource = devices;
        }
    }
}
