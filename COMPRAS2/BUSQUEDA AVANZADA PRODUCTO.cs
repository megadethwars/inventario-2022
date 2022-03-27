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
    public partial class BUSQUEDA_AVANZADA : Form
    {
        List<Tuple<Int32, String>> listaEstatus;
        List<Tuple<Int32, String>> listaLugares;

        public BUSQUEDA_AVANZADA(Devices devices)
        {
            InitializeComponent();
            listaEstatus = new List<Tuple<int, string>>();
            listaLugares = new List<Tuple<int, string>>();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async Task<int> Estatus()
        {
            try
            {
                var url = HttpMethods.url + "statusDevices";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno del servidor");
                    return 2;
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("Estatus no encontrados");
                    return 2;
                }

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }

                var estatus = JsonConvert.DeserializeObject<List<StatusDevices>>(statusmessage.data);

                for (int x = 0; x < estatus.Count; x++)
                {
                    listaEstatus.Add(Tuple.Create<Int32, String>(estatus[x].id, estatus[x].descripcion));
                }
                cbEstatus.DataSource = listaEstatus;
                cbEstatus.DisplayMember = "Item2";
                cbEstatus.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async Task<int> Lugares()
        {
            try
            {
                var url = HttpMethods.url + "lugares";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno del servidor");
                    return 2;
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("Estatus no encontrados");
                    return 2;
                }

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }

                var lugares = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);

                for (int x = 0; x < lugares.Count; x++)
                {
                    listaLugares.Add(Tuple.Create<Int32, String>(lugares[x].id, lugares[x].lugar));
                }
                cbLugares.DataSource = listaLugares;
                cbLugares.DisplayMember = "Item2";
                cbLugares.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async void BUSQUEDA_AVANZADA_Load(object sender, EventArgs e)
        {
            int status = await Estatus();
            int lugars = await Lugares();
        }

        private void txtProducto_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "Introduzca el Producto")
            {
                txtProducto.Clear();
            }
        }
        
        private void txtCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "Introduzca el Codigo")
            {
                txtCodigo.Clear();
            }
        }
        
        private void txtMarca_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == "Introduzca la Marca")
            {
                txtMarca.Clear();
            }
        }
       
        private void txtModelo_Click(object sender, EventArgs e)
        {
            if (txtModelo.Text == "Introduzca el Modelo")
            {
                txtModelo.Clear();
            }
        }
        
        private void txtSerie_Click(object sender, EventArgs e)
        {
            if (txtSerie.Text == "Introduzca la Serie")
            {
                txtSerie.Clear();
            }
        }
    }
}
