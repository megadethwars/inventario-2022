﻿using COMPRAS2.modelos;
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
        List<Devices> devices;

        int iddevice = 0;



        public BUSQUEDA_AVANZADA_REPORTE()
        {
            InitializeComponent();
            dtpReporte.CustomFormat = "yyyy-MM-dd";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        public async void busqueda()
        {          
            QueryReporte reportequery = new QueryReporte();

            QueryDevice devicequery = new QueryDevice();

            if (txtCodigo.Text != "")
            {
                devicequery.codigo = txtCodigo.Text;
            }

            if (dtpReporte.Text != "")
            {
                reportequery.fechaAltaRangoInicio = dtpReporte.Text;
            }

            string jsonD = JsonConvert.SerializeObject(devicequery,
            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var urlD = HttpMethods.url + "dispositivos/query";
            StatusMessage statusmessageD = await HttpMethods.Post(urlD, jsonD);

            if (statusmessageD.statuscode == 500)
            {
                MessageBox.Show("Error interno en el servidor");
                return;
            }

            if (statusmessageD.statuscode == 409)
            {
                MessageBox.Show("Ocurrio un conflicto en busqueda de productos");
                return;
            }

            if (statusmessageD.statuscode == 400)
            {
                MessageBox.Show("No hay campos seleccionados a consultar");
                return;
            }

            if (statusmessageD.statuscode == 404)
            {
                MessageBox.Show("producto NO encontrado");
                return;
            }

            if (statusmessageD.statuscode == 200)
            {
                devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessageD.data);

                if (devices.Count == 0)
                {
                    MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                    dgvReportes.DataSource = null;
                    return;
                }
                iddevice = devices[0].id;

                reportequery.dispositivoId = iddevice;
            }

            string json = JsonConvert.SerializeObject(reportequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "reportes/query";
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
                List<Reportes> reporte = JsonConvert.DeserializeObject<List<Reportes>>(statusmessage.data);

                for (int x = 0; x < reporte.Count; x++)
                {
                    Devices Dispositivos = reporte[x].dispositivo;
                    reporte[x].dispositivoActual = Dispositivos.producto;

                    User Usuarios = reporte[x].usuario;
                    reporte[x].UserActual = Usuarios.nombre + " " + Usuarios.apellidoPaterno;

                    User UsuariosA = reporte[x].usuario;
                    reporte[x].UserActualA = UsuariosA.apellidoPaterno;

                    Devices Codigos = reporte[x].dispositivo;
                    reporte[x].dispositivoCodigo = Codigos.codigo;

                }

                if (reporte.Count == 0)
                {
                    MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                    dgvReportes.DataSource = null;
                    return;
                }               

                dgvReportes.DataSource = reporte;

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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = null;
            this.txtCodigo.Text = null;           
        }

        private void dgvReportes_CellClick(object sender, DataGridViewCellEventArgs e)
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



        private void BUSQUEDA_AVANZADA_REPORTE_Load(object sender, EventArgs e)
        {
           
           if(cbReportes.Checked == true)
           {
                dtpReporte.Enabled = true;
           }
        }

        private void cbReportes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReportes.Checked == true)
            {
                dtpReporte.Enabled = true;
            }else
            {
                dtpReporte.Enabled = false;
                //dtpReporte.Value = null;
            }

        }
    }
}
