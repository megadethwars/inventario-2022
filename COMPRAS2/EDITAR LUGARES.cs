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
    public partial class EDITAR_LUGARES : Form
    {
        int id = 0;
        Lugares lug;
        public EDITAR_LUGARES(Lugares lug)
        {
            InitializeComponent();
            this.lug = lug;
            id = lug.id;
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void EDITAR_LUGARES_Load(object sender, EventArgs e)
        {
            this.txtLugar.Text = lug.lugar;
        }

        private async void EditarEmpleado()
        {           
            Lugares lugarUpdate;
            lugarUpdate = new Lugares();

            lugarUpdate.lugar = txtLugar.Text;

            lugarUpdate.id = id;

            string json = JsonConvert.SerializeObject(lugarUpdate,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "lugares";
            StatusMessage statusmessage = await HttpMethods.put(url, json);

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("error en el servicio, " + statusmessage.message);
                return;
            }

            else if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("error en el servicio");
                return;
            }
            else if (statusmessage.statuscode == 200)
            {
                Lugares LUGARS = JsonConvert.DeserializeObject<Lugares>(statusmessage.data);
                MessageBox.Show("LUGAR ACTUALIZADO CORRECTAMENTE");
                Navigator.nextPage(new LUGARES());
                return;
            }
            else if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("error en el servicio, NO encontrado");

                return;
            }
            else
            {
                MessageBox.Show("Bad request, algunos campos faltantes");
                return;
            }

            Navigator.backPage(this.Name, this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditarEmpleado();
        }
    }
}
