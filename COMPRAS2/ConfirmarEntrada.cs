using COMPRAS2.modelos;
using COMPRAS2.servicios;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    public partial class ConfirmarEntrada : Form
    {
        public CarritoEntrada carrito;

        List<Tuple<Int32, String>> listaLugares;

        private int idlugar=1;
        private int idUsuario;
        public string uniqueId;
        public ConfirmarEntrada(CarritoEntrada carrito)
        {
            InitializeComponent();
            this.carrito = carrito;
            uniqueId = Guid.NewGuid().ToString("D");
            listaLugares = new List<Tuple<Int32, String>>();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmarEntrada_Load(object sender, EventArgs e)
        {

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


        private async Task<int> sendMovementAsync()
        {

            try
            {

                foreach (Movimientos movement in this.carrito.entrada.movimientos)
                {

                    //actualizar lugar del dispositivo


                    movement.LugarId = idlugar;
                    movement.usuarioId = idUsuario;
                    movement.usuario = null;
                    movement.dispositivo_Actual = null;
                    movement.cantidad_Actual = 0;
                    movement.codigo_Actual = null;
                    movement.dispositivo = null;
                    movement.idMovimiento = uniqueId;

                    List<Movimientos> movimientos = new List<Movimientos>();
                    movimientos.Add(movement);

                    string json = JsonConvert.SerializeObject(movimientos,
                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                    var url = HttpMethods.url + "movimientos";
                    StatusMessage statusmessage = await HttpMethods.Post(url, json);

                    if (statusmessage.statuscode == 409)
                    {

                    }

                    else if (statusmessage.statuscode == 500)
                    {

                    }
                    else if (statusmessage.statuscode == 200)
                    {


                    }
                    else if (statusmessage.statuscode == 404)
                    {
                        MessageBox.Show("error en el servicio, NO encontrado");


                    }
                    movimientos.Clear();
                    movimientos = null;
                }

                Navigator.nextPage(new PDFMovement(uniqueId));

                return 0;
            }
            catch (Exception ex)
            {
                return 10;
            }
        }


    }
}
