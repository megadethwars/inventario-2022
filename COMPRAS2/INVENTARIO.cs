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

namespace COMPRAS2
{
    public partial class INVENTARIO : Form
    {
        string url = "https://avsinventoryswagger25.azurewebsites.net/api/v1/";

        MENU mainmenu;
        public Devices devices;
        public List<Devices> deviceslist;
        public INVENTARIO()
        {
            InitializeComponent();
            deviceslist= new List<Devices>();
        }     
        
        private async void INVENTARIO_Load(object sender, EventArgs e)
        {
            try
            {
                var url = HttpMethods.url + "dispositivos?limit=100";
                StatusMessage statusmessage = await HttpMethods.get(url);

                deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                int i = 0;
                foreach (Devices device in deviceslist)
                {
                    Lugares lugar = device.lugar;
                    deviceslist[i].Lugar_Actual = lugar.lugar;

                    StatusDevices status = device.status;
                    deviceslist[i].StatusActual = status.descripcion;
                    i++;
                }

                dgvInventario.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvInventario.Columns.Add("ID", "ID");
                dgvInventario.Columns.Add("CANTIDAD", "CANTIDAD");
                dgvInventario.Columns.Add("LUGAR", "LUGAR");
                dgvInventario.Columns.Add("MARCA", "MARCA");
                dgvInventario.Columns.Add("MODELO", "MODELO");
                dgvInventario.Columns.Add("ESTATUS", "ESTATUS");

                for (int x = 0; x < deviceslist.Count; x++)
                {
                    Devices inv = deviceslist[x];
                    deviceslist[x].producto = inv.producto;
                    deviceslist[x].codigo = inv.codigo;
                    deviceslist[x].cantidad = inv.cantidad;
                    deviceslist[x].Lugar_Actual = inv.Lugar_Actual;
                    deviceslist[x].marca = inv.marca;
                    deviceslist[x].modelo = inv.modelo;
                    deviceslist[x].StatusActual = inv.StatusActual;

                    string[] row = new string[] { deviceslist[x].producto, deviceslist[x].codigo,
                    deviceslist[x].cantidad.ToString(), deviceslist[x].Lugar_Actual.ToString(),
                    deviceslist[x].marca, deviceslist[x].modelo, deviceslist[x].StatusActual};
                    dgvInventario.Rows.Add(row);
                }


                //var url = HttpMethods.url + "dispositivos?limit=100";
                //StatusMessage statusmessage = await HttpMethods.get(url);

                //if (statusmessage.statuscode != 200)
                //{
                //    return;
                //}

                //deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                //int x = 0;
                //foreach (Devices device in deviceslist)
                //{

                //    Lugares lugar = device.lugar;
                //    deviceslist[x].Lugar_Actual = lugar.lugar;

                //    StatusDevices status = device.status;
                //    deviceslist[x].StatusActual = status.descripcion;
                //    x = x + 1;
                //}


                //dgvInventario.DataSource = deviceslist;
                //this.dgvInventario.Columns["lugar"].Visible = false;
                //this.dgvInventario.Columns["lugarId"].Visible = false;
                //this.dgvInventario.Columns["status"].Visible = false;
                //this.dgvInventario.Columns["statusId"].Visible = false;
                //this.dgvInventario.Columns["Compra"].Visible = false;
                //this.dgvInventario.Columns["Descompostura"].Visible = false;
                //this.dgvInventario.Columns["Foto"].Visible = false;
                //this.dgvInventario.Columns["IdMov"].Visible = false;
                //this.dgvInventario.Columns["Observaciones"].Visible = false;
                //this.dgvInventario.Columns["Origen"].Visible = false;
                //this.dgvInventario.Columns["Pertenece"].Visible = false;
                //this.dgvInventario.Columns["Proveedor"].Visible = false;
                //this.dgvInventario.Columns["Costo"].Visible = false;
                //this.dgvInventario.Columns["FechaUltimaModificacion"].Visible = false;
                //this.dgvInventario.Columns["id"].Visible = false;
                //this.dgvInventario.Columns["accesorios"].Visible = false;
                //this.dgvInventario.Columns["serie"].Visible = false;
                //this.dgvInventario.Columns["fechaAlta"].Visible = false;

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
            Navigator.nextPage(new SALIDA());
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
                //MessageBox.Show(dgvInventario.CurrentCell.Value.ToString());
                //Devices datas = dgvInventario.CurrentCell.RowIndex;
                //Devices data = (Devices)cell.

                DataGridViewRow cell = dgvInventario.Rows[e.RowIndex];
  
                DataGridViewCellCollection columns = cell.Cells;

                var index =columns[1];
                var codigo = index.FormattedValue;

              
                var datafind =deviceslist.Find(x => x.codigo.Contains((string)codigo));


                
                Navigator.nextPage(new DETALLES_DEL_PRODUCTO(datafind));
                
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

            try
            {
                var url = HttpMethods.url + "dispositivos?limit=100";
                StatusMessage statusmessage = await HttpMethods.get(url);

                deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                int i = 0;
                foreach (Devices device in deviceslist)
                {

                    Lugares lugar = device.lugar;
                    deviceslist[i].Lugar_Actual = lugar.lugar;

                    StatusDevices status = device.status;
                    deviceslist[i].StatusActual = status.descripcion;
                    i++;
                }

                dgvInventario.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvInventario.Columns.Add("ID", "ID");
                dgvInventario.Columns.Add("CANTIDAD", "CANTIDAD");
                dgvInventario.Columns.Add("LUGAR", "LUGAR");
                dgvInventario.Columns.Add("MARCA", "MARCA");
                dgvInventario.Columns.Add("MODELO", "MODELO");
                dgvInventario.Columns.Add("ESTATUS", "ESTATUS");

                for (int x = 0; x < deviceslist.Count; x++)
                {
                    Devices inv = deviceslist[x];
                    deviceslist[x].producto = inv.producto;
                    deviceslist[x].codigo = inv.codigo;
                    deviceslist[x].cantidad = inv.cantidad;
                    deviceslist[x].Lugar_Actual = inv.Lugar_Actual;
                    deviceslist[x].marca = inv.marca;
                    deviceslist[x].modelo = inv.modelo;
                    deviceslist[x].StatusActual = inv.StatusActual;

                    string[] row = new string[] { deviceslist[x].producto, deviceslist[x].codigo,
                    deviceslist[x].cantidad.ToString(), deviceslist[x].Lugar_Actual.ToString(),
                    deviceslist[x].marca, deviceslist[x].modelo, deviceslist[x].StatusActual};
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

        private async void busquedaNormal()
        {
            try
            {           
                deviceslist.Clear();

                var url = HttpMethods.url + "dispositivos/filter/"+txtBUSCADOR.Text+"?limit=30";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return;
                }

                deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                int i = 0;
                foreach (Devices device in deviceslist)
                {
                    Lugares lugar = device.lugar;
                    deviceslist[i].Lugar_Actual = lugar.lugar;

                    StatusDevices status = device.status;
                    deviceslist[i].StatusActual = status.descripcion;
                    i++;
                }

                dgvInventario.Columns.Add("PRODUCTO", "PRODUCTO");
                dgvInventario.Columns.Add("ID", "ID");
                dgvInventario.Columns.Add("CANTIDAD", "CANTIDAD");
                dgvInventario.Columns.Add("LUGAR", "LUGAR");
                dgvInventario.Columns.Add("MARCA", "MARCA");
                dgvInventario.Columns.Add("MODELO", "MODELO");
                dgvInventario.Columns.Add("ESTATUS", "ESTATUS");

                for (int x = 0; x < deviceslist.Count; x++)
                {
                    Devices inv = deviceslist[x];
                    deviceslist[x].producto = inv.producto;
                    deviceslist[x].codigo = inv.codigo;
                    deviceslist[x].cantidad = inv.cantidad;
                    deviceslist[x].Lugar_Actual = inv.Lugar_Actual;
                    deviceslist[x].marca = inv.marca;
                    deviceslist[x].modelo = inv.modelo;
                    deviceslist[x].StatusActual = inv.StatusActual;

                    string[] row = new string[] { deviceslist[x].producto, deviceslist[x].codigo,
                    deviceslist[x].cantidad.ToString(), deviceslist[x].Lugar_Actual.ToString(),
                    deviceslist[x].marca, deviceslist[x].modelo, deviceslist[x].StatusActual};
                    dgvInventario.Rows.Add(row);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {
            busquedaNormal();
        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvInventario_Scroll(object sender, ScrollEventArgs e)
        {
            //MessageBox.Show("tu mama");
        }
    }
    
}
