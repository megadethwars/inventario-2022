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
            try
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

                    User Usuarios = reportes[x].usuario;
                    reportes[x].UserActual = Usuarios.nombre + " " + Usuarios.apellidoPaterno;

                    User UsuariosA = reportes[x].usuario;
                    reportes[x].UserActualA = UsuariosA.apellidoPaterno;

                    Devices Codigos = reportes[x].dispositivo;
                    reportes[x].dispositivoCodigo = Codigos.codigo;

                }
            
                dgvReportes.DataSource = reportes;
                this.dgvReportes.Columns["foto"].Visible = false;
                this.dgvReportes.Columns["fechaUltimaModificacion"].Visible = false;
                this.dgvReportes.Columns["UserActualA"].Visible = false;
                this.dgvReportes.Columns["dispositivoCodigo"].Visible = false;
                this.dgvReportes.Columns["dispositivoId"].Visible = false;
                this.dgvReportes.Columns["Id"].Visible = false;
                this.dgvReportes.Columns["usuarioId"].Visible = false;
                this.dgvReportes.Columns["dispositivo"].Visible = false;
                this.dgvReportes.Columns["usuario"].Visible = false;
                this.dgvReportes.Columns["comentarios"].Visible = false;
            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
            

        }
        

        public void dgvReportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvReportes.Rows[e.RowIndex];
                Reportes data = (Reportes)cell.DataBoundItem;

                Navigator.nextPage(new DETALLES_REPORTE(data));
                
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = null;
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
                
                User Usuarios = reportes[x].usuario;
                reportes[x].UserActual = Usuarios.nombre + " " + Usuarios.apellidoPaterno;

                User UsuariosA = reportes[x].usuario;
                reportes[x].UserActualA = Usuarios.apellidoPaterno;
                
                Devices Codigos = reportes[x].dispositivo;
                reportes[x].dispositivoCodigo = Codigos.codigo;

                
            }

            dgvReportes.DataSource = reportes;
            this.dgvReportes.Columns["foto"].Visible = false;
            this.dgvReportes.Columns["fechaUltimaModificacion"].Visible = false;
            this.dgvReportes.Columns["UserActualA"].Visible = false;
            this.dgvReportes.Columns["dispositivoCodigo"].Visible = false;
            this.dgvReportes.Columns["dispositivoId"].Visible = false;
            this.dgvReportes.Columns["Id"].Visible = false;
            this.dgvReportes.Columns["usuarioId"].Visible = false;
            this.dgvReportes.Columns["dispositivo"].Visible = false;
            this.dgvReportes.Columns["usuario"].Visible = false;
            this.dgvReportes.Columns["comentarios"].Visible = false;
        }

        private void dgvReportes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvReportes.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new BUSQUEDA_AVANZADA_REPORTE());
        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            txtBUSCADOR.Clear();
        }
    }
}
