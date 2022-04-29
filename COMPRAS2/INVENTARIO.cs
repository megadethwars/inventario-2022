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
        Devices devices;
        List<Devices> deviceslist;
        public INVENTARIO()
        {
            InitializeComponent();
            deviceslist= new List<Devices>();
        }     
        
        private async void INVENTARIO_Load(object sender, EventArgs e)
        {
            try
            {
                var url = HttpMethods.url + "dispositivos?limit=10000";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return;
                }

                deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                for (int x = 0; x < deviceslist.Count; x++)
                {

                    Lugares lugar = deviceslist[x].lugar;
                    deviceslist[x].Lugar_Actual = lugar.lugar;

                    StatusDevices status = deviceslist[x].status;
                    deviceslist[x].StatusActual = status.descripcion;
                }

                dgvInventario.DataSource = deviceslist;
                //dgvInventario.FirstDisplayedScrollingRowIndex = deviceslist;
                this.dgvInventario.Columns["lugar"].Visible = false;
                this.dgvInventario.Columns["lugarId"].Visible = false;
                this.dgvInventario.Columns["status"].Visible = false;
                this.dgvInventario.Columns["statusId"].Visible = false;
                this.dgvInventario.Columns["Compra"].Visible = false;
                this.dgvInventario.Columns["Descompostura"].Visible = false;
                this.dgvInventario.Columns["Foto"].Visible = false;
                this.dgvInventario.Columns["IdMov"].Visible = false;
                this.dgvInventario.Columns["Observaciones"].Visible = false;
                this.dgvInventario.Columns["Origen"].Visible = false;
                this.dgvInventario.Columns["Pertenece"].Visible = false;
                this.dgvInventario.Columns["Proveedor"].Visible = false;
                this.dgvInventario.Columns["Costo"].Visible = false;
                this.dgvInventario.Columns["FechaUltimaModificacion"].Visible = false;
                this.dgvInventario.Columns["id"].Visible = false;
                this.dgvInventario.Columns["accesorios"].Visible = false;
                this.dgvInventario.Columns["serie"].Visible = false;
                this.dgvInventario.Columns["fechaAlta"].Visible = false;

            }
            catch
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
                DataGridViewRow cell = dgvInventario.Rows[e.RowIndex];
                Devices data =(Devices)cell.DataBoundItem;

                Navigator.nextPage(new DETALLES_DEL_PRODUCTO(data));
                
            }
            catch(Exception ex)
            {
                return;
            }
        }
        

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvInventario.DataSource = null;

            try
            {
                var url = HttpMethods.url + "dispositivos?limit=10000";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return;
                }

                deviceslist = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                for (int x = 0; x < deviceslist.Count; x++)
                {

                    Lugares lugar = deviceslist[x].lugar;
                    deviceslist[x].Lugar_Actual = lugar.lugar;

                    StatusDevices status = deviceslist[x].status;
                    deviceslist[x].StatusActual = status.descripcion;
                }

                dgvInventario.DataSource = deviceslist;
                this.dgvInventario.Columns["lugar"].Visible = false;
                this.dgvInventario.Columns["lugarId"].Visible = false;
                this.dgvInventario.Columns["status"].Visible = false;
                this.dgvInventario.Columns["statusId"].Visible = false;
                this.dgvInventario.Columns["Compra"].Visible = false;
                this.dgvInventario.Columns["Descompostura"].Visible = false;
                this.dgvInventario.Columns["Foto"].Visible = false;
                this.dgvInventario.Columns["IdMov"].Visible = false;
                this.dgvInventario.Columns["Observaciones"].Visible = false;
                this.dgvInventario.Columns["Origen"].Visible = false;
                this.dgvInventario.Columns["Pertenece"].Visible = false;
                this.dgvInventario.Columns["Proveedor"].Visible = false;
                this.dgvInventario.Columns["Costo"].Visible = false;
                this.dgvInventario.Columns["FechaUltimaModificacion"].Visible = false;
                this.dgvInventario.Columns["id"].Visible = false;
                this.dgvInventario.Columns["accesorios"].Visible = false;
                this.dgvInventario.Columns["serie"].Visible = false;
                this.dgvInventario.Columns["fechaAlta"].Visible = false;
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

                List<Devices> devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                for (int x = 0; x < devices.Count; x++)
                {

                    Lugares lugar = devices[x].lugar;
                    devices[x].Lugar_Actual = lugar.lugar;

                    StatusDevices status = devices[x].status;
                    devices[x].StatusActual = status.descripcion;
                }

                dgvInventario.DataSource = devices;
                this.dgvInventario.Columns["lugar"].Visible = false;
                this.dgvInventario.Columns["lugarId"].Visible = false;
                this.dgvInventario.Columns["status"].Visible = false;
                this.dgvInventario.Columns["statusId"].Visible = false;
                this.dgvInventario.Columns["Compra"].Visible = false;
                this.dgvInventario.Columns["Descompostura"].Visible = false;
                this.dgvInventario.Columns["Foto"].Visible = false;
                this.dgvInventario.Columns["IdMov"].Visible = false;
                this.dgvInventario.Columns["Observaciones"].Visible = false;
                this.dgvInventario.Columns["Origen"].Visible = false;
                this.dgvInventario.Columns["Pertenece"].Visible = false;
                this.dgvInventario.Columns["Proveedor"].Visible = false;
                this.dgvInventario.Columns["Costo"].Visible = false;
                this.dgvInventario.Columns["FechaUltimaModificacion"].Visible = false;
                this.dgvInventario.Columns["id"].Visible = false;
                this.dgvInventario.Columns["accesorios"].Visible = false;
                this.dgvInventario.Columns["serie"].Visible = false;
                this.dgvInventario.Columns["fechaAlta"].Visible = false;
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
    }
    
}
