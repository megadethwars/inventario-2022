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
        string url = "https://avsinventoryswagger.azurewebsites.net/api/v1/";

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
            //string respuesta = await Gethttp();
            //List<PostViewModel> lst = JsonConvert.DeserializeObject<List<PostViewModel>>(respuesta);

            //List<Lugares> lugares = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);
            //var id = lugares[2].activo;
            //var lugar =lugares[2].lugar;

            List<Devices> devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

            //dataGridView1.DataSource = lugares;
            dataGridView1.DataSource = devices;
        }

        public async Task<string> Gethttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
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

        private void brnOPCIONES_Click(object sender, EventArgs e)
        {
            //AbrirFormHija(new MIPERFIL());
            Navigator.nextPage(new MIPERFIL());
        }

        private void bkBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
            
        }
    }
}
