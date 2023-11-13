using COMPRAS2.modelos;
using COMPRAS2.servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Threading;

namespace COMPRAS2
{
    public partial class INVENTARIO : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        System.Timers.Timer timer1;
        
       
        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.INVENTARIOTITLE.Font = new Font(ff, 26, fontStyle);
            this.btnBusquedaAvanzada.Font = new Font(ff, 20, fontStyle);
            this.btnActualizar.Font = new Font(ff, 20, fontStyle);
            this.btnAgregarNuevoProducto.Font = new Font(ff, 20, fontStyle);
            this.btnReingresarProducto.Font = new Font(ff, 20, fontStyle);
            this.btnSALIDA.Font = new Font(ff, 20, fontStyle);
            this.btnActualizarBDD.Font = new Font(ff, 20, fontStyle);
            this.btnActualizarProducto.Font = new Font(ff, 20, fontStyle);
            this.btnEditarMovimientos.Font = new Font(ff, 20, fontStyle);
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

        string url = "https://avsinventoryswagger25.azurewebsites.net/api/v1/";

        MENU mainmenu;
        public Lugares L;
        public Devices devices;
        public List<Devices> deviceslist;       
        public List<DeviceSomeFields> deviceslist2;
        ScrollBars vscrolls;
        VScrollBar bar;
        int offssetpage = 25;
        int page = 1;
        bool isEnd = false;
        bool isFiltering = false;
        bool isRunning = false;
        public INVENTARIO()
        {
            InitializeComponent();
            deviceslist= new List<Devices>();
            dgvInventario.Scroll += new System.Windows.Forms.ScrollEventHandler(DataGridView1_Scroll);
            ScrollBars vscrolls = dgvInventario.ScrollBars;
            bar = new VScrollBar();
            offssetpage = VG.offssetpage;
            timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Elapsed += timer1_Tick;
            //timer1.Enabled = true;
            //CheckForIllegalCrossThreadCalls = false;
            deviceslist2 = new List<DeviceSomeFields>();
            L = new Lugares();
            
        }

        private async void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            
            if (e.NewValue >= (dgvInventario.Rows.Count - offssetpage))            
            {
                try
                {
                                    
                //obtener siguiente linea
                    page = page + 1;
                    string url = "";
                    if (isFiltering)
                    {
                        //url = HttpMethods.url + "dispositivos/filter/" + txtBUSCADOR.Text + "?limit=30&offset=" + page.ToString();

                        var url2 = HttpMethods.url + "dispositivos/filterdeviceFields?limit=30&offset=" + page.ToString();
                        StatusMessage statusmessage2 = await HttpMethods.get(url2, txtBUSCADOR.Text);
                        deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);
                    }
                    else
                    {
                        //url = HttpMethods.url + "dispositivos?offset=" + page.ToString() + "&limit=50";
                        //StatusMessage statusmessage = await HttpMethods.get(url);
                        //deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                        var url2 = HttpMethods.url + "dispositivos/alldeviceSomeFields?offset=" + page.ToString() + "&limit=50";
                        StatusMessage statusmessage2 = await HttpMethods.get(url2);
                        deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);
                    }
                                     
                    if (deviceslist2.Count == 0) 
                    {
                        return;
                    }
                    //int i = 0;
                    //foreach (Devices device in deviceslist)
                    //{
                    //    Lugares lugar = device.lugar;
                    //    deviceslist[i].Lugar_Actual = lugar.lugar;

                    //    StatusDevices status = device.status;
                    //    deviceslist[i].StatusActual = status.descripcion;
                    //    i++;
                    //}

                    //for (int x = 0; x < deviceslist.Count; x++)
                    //{
                    //    Devices inv = deviceslist[x];
                    //    deviceslist[x].producto = inv.producto;
                    //    deviceslist[x].codigo = inv.codigo;
                    //    deviceslist[x].Lugar_Actual = inv.Lugar_Actual;
                    //    deviceslist[x].marca = inv.marca;
                    //    deviceslist[x].modelo = inv.modelo;
                    //    deviceslist[x].StatusActual = inv.StatusActual;
                    //    deviceslist[x].serie = inv.serie;

                    //    string[] row = new string[] { deviceslist[x].producto, deviceslist[x].codigo,
                    //    deviceslist[x].Lugar_Actual.ToString(), deviceslist[x].marca, deviceslist[x].modelo,
                    //    deviceslist[x].StatusActual, deviceslist[x].serie};
                    //    dgvInventario.Rows.Add(row);
                    //}

                    

                    for (int x = 0; x < deviceslist2.Count; x++)
                    {
                        DeviceSomeFields inv = deviceslist2[x];
                        deviceslist2[x].producto = inv.producto;
                        deviceslist2[x].codigo = inv.codigo;
                        deviceslist2[x].lugar = inv.lugar;
                        deviceslist2[x].marca = inv.marca;
                        deviceslist2[x].modelo = inv.modelo;
                        deviceslist2[x].descripcion = inv.descripcion;
                        deviceslist2[x].serie = inv.serie;

                        string[] row = new string[] { deviceslist2[x].producto, deviceslist2[x].codigo,
                        deviceslist2[x].lugar, deviceslist2[x].marca, deviceslist2[x].modelo,
                        deviceslist2[x].descripcion, deviceslist2[x].serie};
                        if (dgvInventario != null)
                        {
                            dgvInventario.Rows.Add(row);
                        }
                    }

                }
                catch(Exception ex)
                {
                    //MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                }
            }
        }

        private async void INVENTARIO_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            try
            {                
                var url2 = HttpMethods.url + "dispositivos/alldeviceSomeFields?limit=30";
                pictureBox6.Visible = true;
                StatusMessage statusmessage2 = await HttpMethods.get(url2);
                pictureBox6.Visible = false;
                deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);
                               
                dgvInventario.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvInventario.Columns.Add("ID", "ID");
                dgvInventario.Columns.Add("LUGAR", "LUGAR");
                dgvInventario.Columns.Add("MARCA", "MARCA");
                dgvInventario.Columns.Add("MODELO", "MODELO");
                dgvInventario.Columns.Add("ESTATUS", "ESTATUS");
                dgvInventario.Columns.Add("SERIE", "SERIE");

                dgvInventario.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvInventario.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                
                for (int x = 0; x < deviceslist2.Count; x++)
                {
                    DeviceSomeFields inv = deviceslist2[x];
                    deviceslist2[x].producto = inv.producto;
                    deviceslist2[x].codigo = inv.codigo;
                    deviceslist2[x].lugar = inv.lugar;
                    deviceslist2[x].marca = inv.marca;
                    deviceslist2[x].modelo = inv.modelo;
                    deviceslist2[x].descripcion = inv.descripcion;
                    deviceslist2[x].serie = inv.serie;

                    string[] row = new string[] { deviceslist2[x].producto, deviceslist2[x].codigo,
                    deviceslist2[x].lugar, deviceslist2[x].marca, deviceslist2[x].modelo,
                    deviceslist2[x].descripcion, deviceslist2[x].serie};
                    dgvInventario.Rows.Add(row);
                }
                dgvInventario.Columns["PRODUCTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvInventario.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInventario.Columns["LUGAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInventario.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInventario.Columns["MODELO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInventario.Columns["ESTATUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInventario.Columns["SERIE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");               
            }            
        }
       
        private void AbrirFormHija(object formhija)
        {
            if (this.mainmenu.PANELCONTENEDOR.Controls.Count > 0)
                this.mainmenu.PANELCONTENEDOR.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mainmenu.PANELCONTENEDOR.Controls.Add(fh);
            this.mainmenu.PANELCONTENEDOR.Tag = fh;
            fh.Show();
        }
        
        private void bkBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);            
        }

        private void btnAgregarNuevoProducto_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new AGREGAR_PRODUCTO());
        }

        private void btnReingresarProducto_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new ENTRADA());
        }

        private void btnSALIDA_Click(object sender, EventArgs e)
        {
            var lugaresPop = new LugaresPopUp(this);
            lugaresPop.Show(this);
            
        }

        public void OpenSalida()
        {
            Navigator.nextPage(new SALIDA(this.L));
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new LUGARES());
        }

        private void btnActualizarBDD_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new ACTUALIZAR_BDD());
        }

        private void btnEditarMovimientos_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new INVENTARIO2());
        }
       
        public void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            try
            {               
                DataGridViewRow cell = dgvInventario.Rows[e.RowIndex];
  
                DataGridViewCellCollection columns = cell.Cells;

                var index =columns[1];
                var codigo = index.FormattedValue;
                //var datafind =deviceslist.Find(x => x.codigo.Contains((string)codigo));

                Navigator.nextPage(new DETALLES_DEL_PRODUCTO((string)codigo));              
            }
            catch(Exception ex)
            {
                return;
            }
        }
        
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvInventario.DataSource = null;
            dgvInventario.Columns.Clear();
            txtBUSCADOR.Clear();
            page = 1;
            isFiltering = false;

            try
            {                             
                var url2 = HttpMethods.url + "dispositivos/alldeviceSomeFields?limit=30";
                StatusMessage statusmessage2 = await HttpMethods.get(url2);
                deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);

                dgvInventario.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvInventario.Columns.Add("ID", "ID");
                dgvInventario.Columns.Add("LUGAR", "LUGAR");
                dgvInventario.Columns.Add("MARCA", "MARCA");
                dgvInventario.Columns.Add("MODELO", "MODELO");
                dgvInventario.Columns.Add("ESTATUS", "ESTATUS");
                dgvInventario.Columns.Add("SERIE", "SERIE");

                for (int x = 0; x < deviceslist2.Count; x++)
                {
                    DeviceSomeFields inv = deviceslist2[x];
                    deviceslist2[x].producto = inv.producto;
                    deviceslist2[x].codigo = inv.codigo;
                    deviceslist2[x].lugar = inv.lugar;
                    deviceslist2[x].marca = inv.marca;
                    deviceslist2[x].modelo = inv.modelo;
                    deviceslist2[x].descripcion = inv.descripcion;
                    deviceslist2[x].serie = inv.serie;

                    string[] row = new string[] { deviceslist2[x].producto, deviceslist2[x].codigo,
                    deviceslist2[x].lugar, deviceslist2[x].marca, deviceslist2[x].modelo,
                    deviceslist2[x].descripcion, deviceslist2[x].serie};
                    dgvInventario.Rows.Add(row);
                }
            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }
        
        private void dgvInventario_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvInventario.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private async void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            this.devices = devices;
            Navigator.nextPage(new BUSQUEDA_AVANZADA(devices));
        }

        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                busquedaNormal();
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            try
            {
                isRunning = false;
                timer1.Stop();
                this.Invoke((MethodInvoker)delegate ()
                {
                    busquedaNormal();

                });
                
            }
            catch (Exception ex) { 

            }
            
        }
        private async void busquedaNormal()
        {
            try
            {
                isRunning = false;
                deviceslist2.Clear();
                //this.Invoke((MethodInvoker)delegate ()
                //{
                //    dgvInventario.Rows.Clear();
                //});
                dgvInventario.Rows.Clear();


                page = 1;
                isFiltering = true;
                var url = HttpMethods.url + "dispositivos/filterdeviceFields?limit=30&offset=" + page.ToString();
                StatusMessage statusmessage2 = await HttpMethods.get(url,txtBUSCADOR.Text);



                if (statusmessage2.statuscode != 200)
                {
                    return;
                }

                deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);

             
            
                for (int x = 0; x < deviceslist2.Count; x++)
                {
                    DeviceSomeFields inv = deviceslist2[x];
                    deviceslist2[x].producto = inv.producto;
                    deviceslist2[x].codigo = inv.codigo;
                    deviceslist2[x].lugar = inv.lugar;
                    deviceslist2[x].marca = inv.marca;
                    deviceslist2[x].modelo = inv.modelo;
                    deviceslist2[x].descripcion = inv.descripcion;
                    deviceslist2[x].serie = inv.serie;

                    string[] row = new string[] { deviceslist2[x].producto, deviceslist2[x].codigo,
                    deviceslist2[x].lugar, deviceslist2[x].marca, deviceslist2[x].modelo,
                    deviceslist2[x].descripcion, deviceslist2[x].serie};


                    //this.Invoke((MethodInvoker)delegate ()
                    //{
                    //    dgvInventario.Rows.Add(row);

                    //});

                    dgvInventario.Rows.Add(row);
                    
                     
                   
                    
                }

                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                timer1.Start();
                isRunning = true;
            }
            catch (Exception ex) { 
            }
            
            //busquedaNormal();
        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvInventario_Scroll(object sender, ScrollEventArgs e)
        {
          
        }
    }   
}
