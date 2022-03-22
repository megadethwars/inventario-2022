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

        public INVENTARIO()
        {
            InitializeComponent();  
        }     
        
        private async void INVENTARIO_Load(object sender, EventArgs e)
        {            
            var url = HttpMethods.url + "dispositivos";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }
           
            List<Devices> devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

            for (int x = 0; x < devices.Count; x++) {

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
            Navigator.nextPage(new INGRESAR_PRODUCTO());
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

            var url = HttpMethods.url + "dispositivos";
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
        }
    }
    
}
