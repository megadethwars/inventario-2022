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
    public partial class REPORTES2 : Form
    {
        public REPORTES2()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnAgregarNuevoReporte_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new REPORTES());
        }

        private async void REPORTES2_Load(object sender, EventArgs e)
        {
            var url = HttpMethods.url + "reportes";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }

            List<Reportes> reportes = JsonConvert.DeserializeObject<List<Reportes>>(statusmessage.data);

            for(int x=0; x<reportes.Count; x++)
            {
                Devices Dispositivos = reportes[x].dispositivo;
                reportes[x].dispositivoActual = Dispositivos.producto;
            }
            
            dgvReportes.DataSource = reportes;
            this.dgvReportes.Columns["foto"].Visible = false;
            this.dgvReportes.Columns["fechaUltimaModificacion"].Visible = false;
        }

        private async void btnRecargar_Click(object sender, EventArgs e)
        {
            var url = HttpMethods.url + "reportes";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }

            List<Reportes> reportes = JsonConvert.DeserializeObject<List<Reportes>>(statusmessage.data);

            for (int x = 0; x < reportes.Count; x++)
            {
                Devices Dispositivos = reportes[x].dispositivo;
                reportes[x].dispositivoActual = Dispositivos.producto;
            }

            dgvReportes.DataSource = reportes;
            this.dgvReportes.Columns["foto"].Visible = false;
            this.dgvReportes.Columns["fechaUltimaModificacion"].Visible = false;
        }
    }
}
