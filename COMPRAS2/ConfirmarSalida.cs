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
using Newtonsoft.Json.Converters;

namespace COMPRAS2
{
    public partial class ConfirmarSalida : Form
    {
        List<Tuple<Int32, String>> listaLugares;

        private int idlugar;
        private int idUsuario;

        public ConfirmarSalida()
        {
            InitializeComponent();
        }

        private async void ConfirmarSalida_Load(object sender, EventArgs e)
        {
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


        private async Task<int> Auth()
        {
            try
            {
                if (tbUsuario.Text == "")
                {
                    MessageBox.Show("campo de usuario vacio");
                    return 1;
                }

                if (tbpass.Text == "")
                {
                    MessageBox.Show("campo de password vacio");
                    return 1;
                }

                modelos.User user = new User();
                user.username = tbUsuario.Text;
                user.password = tbpass.Text;
                user.id = 0;
                user.rolId = 0;
                user.nombre = null;
                user.statusId = 0;
                user.telefono = null;
                user.correo = null;



                string json = JsonConvert.SerializeObject(user,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "usuarios/login";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);

                if (statusmessage.statuscode == 404)
                {

                    MessageBox.Show("Usuario no encontrado");
                    return 2;
                }

                if (statusmessage.statuscode == 401)
                {

                    MessageBox.Show("Usuario y/o contraseña incorrecto");
                    return 2;
                }

                if (statusmessage.statuscode == 500)
                {

                    MessageBox.Show("Error interno del servidor");
                    return 2;
                }

                if (statusmessage.statuscode != 201)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                    return 2;
                }

                User userDeserialize = JsonConvert.DeserializeObject<User>(statusmessage.data, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.SSSSSSz" });
                idUsuario = userDeserialize.id;
                


                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }

        }

        private async void btAceptar_Click(object sender, EventArgs e)
        {
            if (idlugar == 0) {
                MessageBox.Show("No se ha asignado algun lugar , intente de nuevo");
            }

            int statusUser = await Auth();

            if (statusUser != 0) {
                return;
            }

            if (cbLugares.SelectedItem != null)
            {
                var idLugarestuple = (Tuple<int, string>)cbLugares.SelectedItem;
                idlugar = idLugarestuple.Item1;           
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun lugar");
                return;
            }
        }
    }
}
