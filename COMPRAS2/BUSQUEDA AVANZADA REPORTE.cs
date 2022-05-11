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
    public partial class BUSQUEDA_AVANZADA_REPORTE : Form
    {
        List<Reportes> reporte;
        public BUSQUEDA_AVANZADA_REPORTE()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        public async void busqueda()
        {          
            QueryReporte reportequery = new QueryReporte();           
            /*
            if (txtNombre.Text != "")
            {
                reportequery.nombre = txtNombre.Text;
            }*/

            if (txtCodigo.Text != "")
            {
                reportequery.codigo = txtCodigo.Text;
            }           

            string json = JsonConvert.SerializeObject(reportequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "usuarios/query";
            StatusMessage statusmessage = await HttpMethods.Post(url, json);

            if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("Error interno en el servidor");
            }

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("Ocurrio un conflicto");
            }

            if (statusmessage.statuscode == 400)
            {
                MessageBox.Show("No hay campos seleccionados a consultar");
            }

            if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("recurso NO encontrado");
            }

            if (statusmessage.statuscode == 200)
            {
                reporte = JsonConvert.DeserializeObject<List<Reportes>>(statusmessage.data);

                if (reporte.Count == 0)
                {
                    MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                    dgvEmpleado.DataSource = null;
                    return;
                }               

                dgvEmpleado.DataSource = reporte;
                /*
                this.dgvEmpleado.Columns["correo"].Visible = false;
                this.dgvEmpleado.Columns["rolId"].Visible = false;
                this.dgvEmpleado.Columns["foto"].Visible = false;
                this.dgvEmpleado.Columns["statusId"].Visible = false;
                this.dgvEmpleado.Columns["password"].Visible = false;
                this.dgvEmpleado.Columns["rol"].Visible = false;
                this.dgvEmpleado.Columns["statusUserDescripcion"].Visible = false;
                this.dgvEmpleado.Columns["status"].Visible = false;
                this.dgvEmpleado.Columns["id"].Visible = false;*/
            }
        }
    }
}
