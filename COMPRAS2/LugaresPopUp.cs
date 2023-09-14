using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMPRAS2.modelos;
using COMPRAS2.servicios;
using Newtonsoft.Json;

namespace COMPRAS2
{
    public partial class LugaresPopUp : Form
    {
        List<Tuple<Int32, String>> listaLugares;
        private INVENTARIO mainForm = null;
        public LugaresPopUp(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as INVENTARIO;
        }

        private async void LugaresPopUp_Load(object sender, EventArgs e)
        {
            listaLugares = new List<Tuple<Int32, String>>();
            int lugars = await Lugares();
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
                listaLugares.Add(Tuple.Create<Int32, String>(0, "ninguno"));
                for (int x = 0; x < lugares.Count; x++)
                {
                    listaLugares.Add(Tuple.Create<Int32, String>(lugares[x].id, lugares[x].lugar));
                }
                comboPlaces.DataSource = listaLugares;
                comboPlaces.DisplayMember = "Item2";
                comboPlaces.ValueMember = "Item1";

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async Task<int> Auth()
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Lugares lugarnew = new Lugares();
                    lugarnew.lugar = textBox1.Text;

                    string json = JsonConvert.SerializeObject(lugarnew,
                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                    var url = HttpMethods.url + "lugares";
                    StatusMessage statusmessage = await HttpMethods.Post(url, json);


                    if (statusmessage.statuscode == 409)
                    {
                        MessageBox.Show("error en el servicio, posiblemente el producto ya exista");
                        return 2;
                    }

                    else if (statusmessage.statuscode == 500)
                    {
                        MessageBox.Show("error en el servicio");
                        return 2;
                    }
                    else if (statusmessage.statuscode == 201)
                    {
                        List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);
                        
                        MessageBox.Show("Locación agregada correctamente.");
                       

                        for (int x = 0; x < devices.Count; x++)
                        {
                            listaLugares.Add(Tuple.Create<Int32, String>(devices[x].id, devices[x].lugar));
                            Console.WriteLine(devices[x].lugar);
                        }
                        comboPlaces.DataSource = null;
                        comboPlaces.DataSource = listaLugares;
                        comboPlaces.DisplayMember = "Item2";
                        comboPlaces.ValueMember = "Item1";
                        comboPlaces.SelectedIndex = listaLugares.Count - 1;
                        textBox1.Text = "";
                        return 0;
                    }
                    else if (statusmessage.statuscode == 404)
                    {
                        MessageBox.Show("error en el servicio, NO encontrado");

                        return 2;
                    }
                    else
                    {
                        return 2;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo");
                    return 10;
                }
            }
            return 10;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int status = await Auth();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listaLugares[comboPlaces.SelectedIndex].Item2 != "ninguno")
            {
                var l = new Lugares();
                l.id = listaLugares[comboPlaces.SelectedIndex].Item1;
                l.lugar = listaLugares[comboPlaces.SelectedIndex].Item2;
                if (l.id == 1)
                {
                    MessageBox.Show("Debes seleccionar un lugar distinto al Almacen");
                    return;
                }
                VG.id_current_lugar = l.id;
                this.mainForm.L = l;
                this.mainForm.OpenSalida();
                this.Close();
            }
        }
    }
}
