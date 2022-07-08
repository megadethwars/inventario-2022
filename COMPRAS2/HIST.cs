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
    public partial class HIST : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblHISTORIAL.Font = new Font(ff, 26, fontStyle);
            this.btnBUSQUEDAAVANZADA.Font = new Font(ff, 18, fontStyle);
            this.btnActualizar.Font = new Font(ff, 18, fontStyle);
            this.btnSalida.Font = new Font(ff, 18, fontStyle);
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

        Movimientos moves;
        List<Movimientos> moveslist;
        public HIST()
        {
            InitializeComponent();
            moveslist = new List<Movimientos>();
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
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            try 
            {
                var url = HttpMethods.url + "movimientos?limit=100";
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
                  
                    Lugares lugar = hist[x].lugar;
                    hist[x].Lugar_Actual = lugar.lugar;

                    User usuario = hist[x].usuario;
                    hist[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + " " + usuario.apellidoMaterno;

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

            var url = HttpMethods.url + "movimientos?limit=100";
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

                Lugares lugar = hist[x].lugar;
                hist[x].Lugar_Actual = lugar.lugar;

                User usuario = hist[x].usuario;
                hist[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + " " + usuario.apellidoMaterno;

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

        public void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvHistorial.Rows[e.RowIndex];
                Movimientos data = (Movimientos)cell.DataBoundItem;

                Navigator.nextPage(new DETALLES_HISTORIAL(data));

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                busquedaNormal();
            }
        }

        private async void busquedaNormal()
        {
            try
            {
                moveslist.Clear();

                var url = HttpMethods.url + "movimientos/filter/" + txtBUSCADOR.Text + "?limit=30";
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

                    Lugares lugar = hist[x].lugar;
                    hist[x].Lugar_Actual = lugar.lugar;

                    User usuario = hist[x].usuario;
                    hist[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + " " + usuario.apellidoMaterno;

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
