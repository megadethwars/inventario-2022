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
            try 
            {
                var url = HttpMethods.url + "movimientos";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return;
                }

                List<Movimientos> hist = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);

                for (int x = 0; x < hist.Count; x++)
                {
                    Devices dispositivo = hist[x].dispositivo;
                    hist[x].dispositivo_Actual = dispositivo.producto;
                    hist[x].codigo_Actual = dispositivo.codigo;

                    User usuario = hist[x].usuario;
                    hist[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + "" + usuario.apellidoMaterno;

                    TipoMovimiento tipoMovimiento = hist[x].tipoMovimiento;
                    hist[x].tipo_Actual = tipoMovimiento.tipo;
                }

                dgvHistorial.DataSource = hist;

                this.dgvHistorial.Columns["foto"].Visible = false;
                this.dgvHistorial.Columns["fechaUltimaModificacion"].Visible = false;
                this.dgvHistorial.Columns["foto2"].Visible = false;
                this.dgvHistorial.Columns["dispositivoId"].Visible = false;
                this.dgvHistorial.Columns["usuarioId"].Visible = false;
                this.dgvHistorial.Columns["LugarId"].Visible = false;
                this.dgvHistorial.Columns["comentarios"].Visible = false;
                this.dgvHistorial.Columns["tipoMovId"].Visible = false;
                this.dgvHistorial.Columns["dispositivo"].Visible = false;
                this.dgvHistorial.Columns["usuario"].Visible = false;
                this.dgvHistorial.Columns["tipoMovimiento"].Visible = false;
                this.dgvHistorial.Columns["idMovimiento"].Visible = false;
            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");                
            }
            
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = null;

            var url = HttpMethods.url + "movimientos";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }

            List<Movimientos> hist = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);

            for (int x = 0; x < hist.Count; x++)
            {
                Devices dispositivo = hist[x].dispositivo;
                hist[x].dispositivo_Actual = dispositivo.producto;
                hist[x].codigo_Actual = dispositivo.codigo;

                User usuario = hist[x].usuario;
                hist[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + "" + usuario.apellidoMaterno;

                TipoMovimiento tipoMovimiento = hist[x].tipoMovimiento;
                hist[x].tipo_Actual = tipoMovimiento.tipo;
            }

            dgvHistorial.DataSource = hist;

            this.dgvHistorial.Columns["foto"].Visible = false;
            this.dgvHistorial.Columns["fechaUltimaModificacion"].Visible = false;
            this.dgvHistorial.Columns["foto2"].Visible = false;
            this.dgvHistorial.Columns["dispositivoId"].Visible = false;
            this.dgvHistorial.Columns["usuarioId"].Visible = false;
            this.dgvHistorial.Columns["LugarId"].Visible = false;
            this.dgvHistorial.Columns["comentarios"].Visible = false;
            this.dgvHistorial.Columns["tipoMovId"].Visible = false;
            this.dgvHistorial.Columns["dispositivo"].Visible = false;
            this.dgvHistorial.Columns["usuario"].Visible = false;
            this.dgvHistorial.Columns["tipoMovimiento"].Visible = false;
        }

        public void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvHistorial.Rows[e.RowIndex];
                Movimientos data = (Movimientos)cell.DataBoundItem;

                //Navigator.nextPage(new DETALLES_HISTORIAL(data));

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
