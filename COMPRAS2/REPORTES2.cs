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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace COMPRAS2
{
    public partial class REPORTES2 : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        int page = 1;
        bool isEnd = false;
        bool isFiltering = false;
        int offssetpage = 25;
        List<Reportes> reporteslist;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblREPORTES.Font = new Font(ff, 26, fontStyle);
            this.btnBusquedaAvanzada.Font = new Font(ff, 20, fontStyle);
            this.btnActualizar.Font = new Font(ff, 20, fontStyle);
            this.btnAgregarNuevoReporte.Font = new Font(ff, 20, fontStyle);
        }

        private void CargoPrivateFontCollection()
        {
            // CREO EL BYTE[] Y TOMO SU LONGITUD
            byte[] fontArray = COMPRAS2.Properties.Resources.Knockout_48;
            int dataLength = COMPRAS2.Properties.Resources.Knockout_48.Length;

            // ASIGNO MEMORIA Y COPIO BYTE[] EN LA DIRECCION
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASO LA FUENTE A LA PRIVATEFONTCOLLECTION
            pfc.AddMemoryFont(ptrData, dataLength);

            //LIBERO LA MEMORIA "UNSAFE"
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }       

        private async void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue >= (dgvReportes.Rows.Count - offssetpage))
            {
                //obtener siguiente linea
                page = page + 1;
                string url = "";
                if (isFiltering)
                {
                    url = HttpMethods.url + "dispositivos/filter/" + txtBUSCADOR.Text + "?limit=30&offset=" + page.ToString();
                }
                else
                {
                    url = HttpMethods.url + "dispositivos?offset=" + page.ToString() + "&limit=50";
                }

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
                    reportes[x].UserActualA = UsuariosA.apellidoPaterno;

                    Devices Codigos = reportes[x].dispositivo;
                    reportes[x].dispositivoCodigo = Codigos.codigo;
                }

                for (int x = 0; x < reportes.Count; x++)
                {
                    Reportes inv = reportes[x];
                    reportes[x].dispositivoActual = inv.dispositivoActual;
                    reportes[x].fechaAlta = inv.fechaAlta;
                    reportes[x].UserActual = inv.UserActual;

                    string[] row = new string[] { reportes[x].dispositivoActual,
                    reportes[x].fechaAlta.ToString(), reportes[x].UserActual.ToString()};
                    dgvReportes.Rows.Add(row);
                }
            }
        }

        public REPORTES2()
        {
            InitializeComponent();
            reporteslist = new List<Reportes>();
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
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            try
            {
                var url = HttpMethods.url + "reportes";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return;
                }

                reporteslist = JsonConvert.DeserializeObject<List<Reportes>>(statusmessage.data);

                for(int x=0; x< reporteslist.Count; x++)
                {
                    Devices Dispositivos = reporteslist[x].dispositivo;
                    reporteslist[x].dispositivoActual = Dispositivos.producto;

                    User Usuarios = reporteslist[x].usuario;
                    reporteslist[x].UserActual = Usuarios.nombre + " " + Usuarios.apellidoPaterno;

                    User UsuariosA = reporteslist[x].usuario;
                    reporteslist[x].UserActualA = UsuariosA.apellidoPaterno;

                    Devices Codigos = reporteslist[x].dispositivo;
                    reporteslist[x].dispositivoCodigo = Codigos.codigo;
                }

                dgvReportes.Columns.Add("DISPOSITIVO", "DISPOSITIVO");
                dgvReportes.Columns.Add("FECHA", "FECHA");
                dgvReportes.Columns.Add("USUARIO", "USUARIO");

                for (int x = 0; x < reporteslist.Count; x++)
                {
                    Reportes inv = reporteslist[x];
                    reporteslist[x].dispositivoActual = inv.dispositivoActual;
                    reporteslist[x].fechaAlta = inv.fechaAlta;
                    reporteslist[x].UserActual = inv.UserActual;
                    
                    string[] row = new string[] { reporteslist[x].dispositivoActual,
                    reporteslist[x].fechaAlta.ToString(), reporteslist[x].UserActual.ToString()};
                    dgvReportes.Rows.Add(row);
                }

                //dgvReportes.DataSource = reportes;
                //this.dgvReportes.Columns["foto"].Visible = false;
                //this.dgvReportes.Columns["fechaUltimaModificacion"].Visible = false;
                //this.dgvReportes.Columns["UserActualA"].Visible = false;
                //this.dgvReportes.Columns["dispositivoCodigo"].Visible = false;
                //this.dgvReportes.Columns["dispositivoId"].Visible = false;
                //this.dgvReportes.Columns["Id"].Visible = false;
                //this.dgvReportes.Columns["usuarioId"].Visible = false;
                //this.dgvReportes.Columns["dispositivo"].Visible = false;
                //this.dgvReportes.Columns["usuario"].Visible = false;
                //this.dgvReportes.Columns["comentarios"].Visible = false;
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

                DataGridViewCellCollection columns = cell.Cells;

                var index = columns[1];
                var codigo = index.FormattedValue;
                var datafind = reporteslist.Find(x => x.fechaAlta.ToString().Contains((string)codigo));
                
                Navigator.nextPage(new DETALLES_REPORTE(datafind));              
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = null;
            dgvReportes.Columns.Clear();
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

            dgvReportes.Columns.Add("DISPOSITIVO", "DISPOSITIVO");
            dgvReportes.Columns.Add("FECHA", "FECHA");
            dgvReportes.Columns.Add("USUARIO", "USUARIO");

            for (int x = 0; x < reportes.Count; x++)
            {
                Reportes inv = reportes[x];
                reportes[x].dispositivoActual = inv.dispositivoActual;
                reportes[x].fechaAlta = inv.fechaAlta;
                reportes[x].UserActual = inv.UserActual;

                string[] row = new string[] { reportes[x].dispositivoActual,
                    reportes[x].fechaAlta.ToString(), reportes[x].UserActual.ToString()};
                dgvReportes.Rows.Add(row);
            }
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
            
        }

        private async void busquedaNormal()
        {
            try
            {
                reporteslist.Clear();
                dgvReportes.Rows.Clear();
                page = 1;
                isFiltering = true;
                var url = HttpMethods.url + "reportes/filter/" + txtBUSCADOR.Text + "?limit=30";
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

                for (int x = 0; x < reportes.Count; x++)
                {
                    Reportes inv = reportes[x];
                    reportes[x].dispositivoActual = inv.dispositivoActual;
                    reportes[x].fechaAlta = inv.fechaAlta;
                    reportes[x].UserActual = inv.UserActual;

                    string[] row = new string[] { reportes[x].dispositivoActual,
                    reportes[x].fechaAlta.ToString(), reportes[x].UserActual.ToString()};
                    dgvReportes.Rows.Add(row);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {
            busquedaNormal();
        }
    }
}
