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
    public partial class EDITAR_REPORTES : Form
    {
        Reportes reportes;
        int id = 0;
        int dispositivoid = 0;
        int usuarioid = 0;

        public EDITAR_REPORTES(Reportes reportes)
        {           
            InitializeComponent();
            this.reportes = reportes;
            id = reportes.id;
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditarReportes();
        }

        private async void EditarReportes()
        {
            Reportes reportesUpdates;
            reportesUpdates = new Reportes();

            reportesUpdates.comentarios = txtComentarios.Text;
            reportesUpdates.dispositivoId = dispositivoid;
            reportesUpdates.usuarioId = usuarioid;
            reportesUpdates.id = id;

            string json = JsonConvert.SerializeObject(reportesUpdates,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "reportes";
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
                Reportes USERS = JsonConvert.DeserializeObject<Reportes>(statusmessage.data);
                MessageBox.Show("REPORTE ACTUALIZADO CORRECTAMENTE");
                Navigator.nextPage(new REPORTES2());
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
        }

        private async void EDITAR_REPORTES_Load(object sender, EventArgs e)
        {
            Reportes reportes;
            reportes = new Reportes();

            reportes.comentarios = txtComentarios.Text;
            reportes.id = id;

            Navigator.nextPage(new REPORTES2());            
        }
    }
}
