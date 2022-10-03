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
        public List<Movimientos> hist;

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
        
        VScrollBar bar;
        Movimientos moves;
        List<Movimientos> moveslist;
        int offssetpage = 25;
        int page = 1;
        bool isFiltering = false;

        public HIST()
        {
            InitializeComponent();
            moveslist = new List<Movimientos>();
            dgvHistorial.Scroll += new System.Windows.Forms.ScrollEventHandler(DataGridView1_Scroll);
            ScrollBars vscrolls = dgvHistorial.ScrollBars;
            bar = new VScrollBar();
            offssetpage = VG.offssetpage;
        }
        
        private async void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue >= (dgvHistorial.Rows.Count - offssetpage))
            {
                //obtener siguiente linea
                page = page + 1;
                string url = "";
                if (isFiltering)
                {
                    url = HttpMethods.url + "movimientos/filter/" + txtBUSCADOR.Text + "?limit=30&offset=" + page.ToString();
                }
                else
                {
                    url = HttpMethods.url + "movimientos?offset=" + page.ToString() + "&limit=50";
                }

                StatusMessage statusmessage = await HttpMethods.get(url);
                hist = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);

                if (hist.Count == 0)
                {
                    return;
                }
                int i = 0;
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

                for (int x = 0; x < hist.Count; x++)
                {
                    Movimientos mov = hist[x];
                    hist[x].fechaAlta = mov.fechaAlta;
                    hist[x].dispositivo_Actual = mov.dispositivo_Actual;
                    hist[x].idMovimiento = mov.idMovimiento;
                    hist[x].Lugar_Actual = mov.Lugar_Actual;
                    hist[x].nombre_Actual = mov.nombre_Actual;
                    hist[x].tipo_Actual = mov.tipo_Actual;

                    string[] row = new string[] { hist[x].fechaAlta.ToString(), hist[x].dispositivo_Actual,
                    hist[x].idMovimiento, hist[x].Lugar_Actual, hist[x].nombre_Actual, hist[x].tipo_Actual};
                    dgvHistorial.Rows.Add(row);
                }
            }
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

                hist = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);

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

                dgvHistorial.Columns.Add("FECHA", "FECHA");
                dgvHistorial.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvHistorial.Columns.Add("ID", "ID");
                dgvHistorial.Columns.Add("LUGAR", "LUGAR");
                dgvHistorial.Columns.Add("NOMBRE", "NOMBRE");
                dgvHistorial.Columns.Add("TIPO", "TIPO");

                for (int x = 0; x < hist.Count; x++)
                {
                    Movimientos mov = hist[x];
                    hist[x].fechaAlta = mov.fechaAlta;
                    hist[x].dispositivo_Actual = mov.dispositivo_Actual;
                    hist[x].idMovimiento = mov.idMovimiento;
                    hist[x].Lugar_Actual = mov.Lugar_Actual;
                    hist[x].nombre_Actual = mov.nombre_Actual;
                    hist[x].tipo_Actual = mov.tipo_Actual;

                    string[] row = new string[] { hist[x].fechaAlta.ToString(), hist[x].dispositivo_Actual, 
                    hist[x].idMovimiento, hist[x].Lugar_Actual, hist[x].nombre_Actual, hist[x].tipo_Actual};
                    dgvHistorial.Rows.Add(row);
                }

                //dgvHistorial.DataSource = hist;
                //this.dgvHistorial.Columns["foto"].Visible = false;
                //this.dgvHistorial.Columns["fechaUltimaModificacion"].Visible = false;
                //this.dgvHistorial.Columns["foto2"].Visible = false;
                //this.dgvHistorial.Columns["dispositivoId"].Visible = false;
                //this.dgvHistorial.Columns["usuarioId"].Visible = false;
                //this.dgvHistorial.Columns["LugarId"].Visible = false;
                //this.dgvHistorial.Columns["comentarios"].Visible = false;
                //this.dgvHistorial.Columns["tipoMovId"].Visible = false;
                //this.dgvHistorial.Columns["dispositivo"].Visible = false;
                //this.dgvHistorial.Columns["usuario"].Visible = false;
                //this.dgvHistorial.Columns["tipoMovimiento"].Visible = false;
                //this.dgvHistorial.Columns["idMovimiento"].Visible = false;
            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");                
            }
            
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = null;
            dgvHistorial.Columns.Clear();          
            txtBUSCADOR.Clear();
            try
            {
                var url = HttpMethods.url + "movimientos?limit=100";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return;
                }

                hist = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);

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

                dgvHistorial.Columns.Add("FECHA", "FECHA");
                dgvHistorial.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvHistorial.Columns.Add("ID", "ID");
                dgvHistorial.Columns.Add("LUGAR", "LUGAR");
                dgvHistorial.Columns.Add("NOMBRE", "NOMBRE");
                dgvHistorial.Columns.Add("TIPO", "TIPO");

                for (int x = 0; x < hist.Count; x++)
                {
                    Movimientos mov = hist[x];
                    hist[x].fechaAlta = mov.fechaAlta;
                    hist[x].dispositivo_Actual = mov.dispositivo_Actual;
                    hist[x].idMovimiento = mov.idMovimiento;
                    hist[x].Lugar_Actual = mov.Lugar_Actual;
                    hist[x].nombre_Actual = mov.nombre_Actual;
                    hist[x].tipo_Actual = mov.tipo_Actual;

                    string[] row = new string[] { hist[x].fechaAlta.ToString(), hist[x].dispositivo_Actual,
                    hist[x].idMovimiento, hist[x].Lugar_Actual, hist[x].nombre_Actual, hist[x].tipo_Actual};
                    dgvHistorial.Rows.Add(row);
                }
            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }

        public void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvHistorial.Rows[e.RowIndex];
                DataGridViewCellCollection columns = cell.Cells;
                Movimientos data = (Movimientos)cell.DataBoundItem;
                var index = columns[1];
                var codigo = index.FormattedValue;
                //var datafind = hist.Find(x => x.dispositivo_Actual.Contains((string)codigo));

                Navigator.nextPage(new DETALLES_HISTORIAL((string)codigo));

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
                dgvHistorial.Rows.Clear();
                page = 1;
                isFiltering = true;
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
                dgvHistorial.Rows.Clear();
                for (int x = 0; x < hist.Count; x++)
                {
                    Movimientos mov = hist[x];
                    hist[x].fechaAlta = mov.fechaAlta;
                    hist[x].dispositivo_Actual = mov.dispositivo_Actual;
                    hist[x].idMovimiento = mov.idMovimiento;
                    hist[x].Lugar_Actual = mov.Lugar_Actual;
                    hist[x].nombre_Actual = mov.nombre_Actual;
                    hist[x].tipo_Actual = mov.tipo_Actual;

                    string[] row = new string[] { hist[x].fechaAlta.ToString(), hist[x].dispositivo_Actual,
                    hist[x].idMovimiento, hist[x].Lugar_Actual, hist[x].nombre_Actual, hist[x].tipo_Actual};
                    dgvHistorial.Rows.Add(row);
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
