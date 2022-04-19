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
    public partial class AGREGAR_EMPLEADO : Form
    {
        List<Tuple<Int32, String>> listaRoles;
        public AGREGAR_EMPLEADO()
        {
            InitializeComponent();
            listaRoles = new List<Tuple<int, string>>();
        }

        private async void AGREGAR_EMPLEADO_Load(object sender, EventArgs e)
        {
            int status = await Roles();
        }

        private async Task<int> Roles()
        {
            try
            {
                var url = HttpMethods.url + "roles";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500) {

                    MessageBox.Show("Error interno del servidor");
                    return 2;
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("Roles no encontrados");
                    return 2;
                }

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }


                var roles = JsonConvert.DeserializeObject<List<Rol>>(statusmessage.data);                

                for (int x = 0; x < roles.Count; x++)
                {

                    listaRoles.Add(Tuple.Create<Int32,String>(roles[x].id,roles[x].nombre));
                }
                cbRoles.DataSource = listaRoles;
                cbRoles.DisplayMember = "Item2";
                cbRoles.ValueMember = "Item1";               

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async Task<int> CreateUser()
        {
            try
            {
                int cantidad = 0;
                Int32 costo = 0;
                int idRol = 0;
                if (txtNombreDelUsuario.Text == "")
                {
                    MessageBox.Show("campo de nombre vacio");
                    return 1;
                }

                if (txtApellidoPaterno.Text == "")
                {
                    MessageBox.Show("campo de apellido paterno vacio");
                    return 1;
                }
                if (txtApellidoMaterno.Text == "")
                {
                    MessageBox.Show("campo de apellido materno esta vacio");
                    return 1;
                }

                if (txtContraseña.Text == "")
                {
                    MessageBox.Show("campo de contraseña vacio");
                    return 1;
                }

                if (txtContraseñaDeNuevo.Text == "")
                {
                    MessageBox.Show("campo de contraseña vacio");
                    return 1;
                }

                if (txtCorreo.Text == "")
                {
                    MessageBox.Show("campo de correo vacio");
                    return 1;
                }

                if (txtTelefono.Text == "")
                {
                    MessageBox.Show("campo de correo vacio");
                    return 1;
                }

                if (cbRoles.SelectedItem != null)
                {
                    var idRoltuple =(Tuple<int, string>)cbRoles.SelectedItem;
                    idRol = idRoltuple.Item1;
                }
                else {
                    MessageBox.Show("No se ha seleccionado ningun rol");
                    return 1;
                }

                //check passwords
                if (txtContraseña.Text != txtContraseñaDeNuevo.Text) {
                    MessageBox.Show("Error en las contraseñas");
                    return 1;
                }


                User user = new User();
                user.apellidoMaterno = txtApellidoMaterno.Text;
                user.apellidoPaterno = txtApellidoPaterno.Text;
                user.nombre = txtNombreDelUsuario.Text;
                user.password = txtContraseña.Text;
                user.rolId = idRol;
                user.telefono = txtTelefono.Text;
                user.correo = txtCorreo.Text;
                user.statusId = 1;
                user.username = txtNombreDelUsuario.Text;
               

                string json = JsonConvert.SerializeObject(user,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "usuarios";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);


                if (statusmessage.statuscode == 409)
                {
                    MessageBox.Show("error en el servicio, "+statusmessage.message);
                    return 2;
                }

                else if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("error en el servicio");
                    return 2;
                }
                else if (statusmessage.statuscode == 201)
                {
                    //var auth = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                    List<User> USERS = JsonConvert.DeserializeObject<List<User>>(statusmessage.data);
                    MessageBox.Show("EMPLEADO AGREGADO CORRECTAMENTE");
                    Navigator.backPage(this.Name, this);
                    return 0;
                }
                else if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("error en el servicio, NO encontrado");

                    return 2;
                }
                else
                {
                    MessageBox.Show("Bad request, algunos campos faltantes");
                    return 2;
                }

                Navigator.backPage(this.Name, this);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo");
                return 10;
            }

        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text != txtContraseñaDeNuevo.Text)
            {
                MessageBox.Show("LAS CONTRASEÑAS NO SON IGUALES, INTENTE DE NUEVO");
                return;
            }
            int status = await CreateUser();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void txtContraseñaDeNuevo_TextChanged(object sender, EventArgs e)
        {
            txtContraseñaDeNuevo.UseSystemPasswordChar = true;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void txtNombreDelUsuario_Click(object sender, EventArgs e)
        {
            if (txtNombreDelUsuario.Text == "Introduzca el Nombre(s) del Usuario")
            {
                txtNombreDelUsuario.Clear();
            }
        }

        private void txtNombreDelUsuario_Leave(object sender, EventArgs e)
        {
            if (txtNombreDelUsuario.Text == "")
            {
                txtNombreDelUsuario.Text = "Introduzca el Nombre(s) del Usuario";
            }
        }

        private void txtApellidoPaterno_Click(object sender, EventArgs e)
        {
            if (txtApellidoPaterno.Text == "Introduzca el Apellido Paterno")
            {
                txtApellidoPaterno.Clear();
            }
        }

        private void txtApellidoPaterno_Leave(object sender, EventArgs e)
        {
            if (txtApellidoPaterno.Text == "")
            {
                txtApellidoPaterno.Text = "Introduzca el Apellido Paterno";
            }
        }

        private void txtApellidoMaterno_Click(object sender, EventArgs e)
        {
            if (txtApellidoMaterno.Text == "Introduzca el Apellido Materno")
            {
                txtApellidoMaterno.Clear();
            }
        }

        private void txtApellidoMaterno_Leave(object sender, EventArgs e)
        {
            if (txtApellidoMaterno.Text == "")
            {
                txtApellidoMaterno.Text = "Introduzca el Apellido Materno";
            }
        }

        private void textUsuario_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text == "Nombre de Usuario")
            {
                textUsuario.Clear();
            }
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Text == "")
            {
                textUsuario.Text = "Nombre de Usuario";
            }
        }

        private void txtContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Introduzca la contraseña")
            {
                txtContraseña.Clear();
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Introduzca la contraseña";
            }
        }

        private void txtContraseñaDeNuevo_Click(object sender, EventArgs e)
        {
            if (txtContraseñaDeNuevo.Text == "Introduzca la contraseña de nuevo")
            {
                txtContraseñaDeNuevo.Clear();
                txtContraseñaDeNuevo.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseñaDeNuevo_Leave(object sender, EventArgs e)
        {
            if (txtContraseñaDeNuevo.Text == "")
            {
                txtContraseñaDeNuevo.Text = "Introduzca la contraseña de nuevo";
            }
        }

        private void txtTelefono_Click(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Introduzca el telefono")
            {
                txtTelefono.Clear();
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Introduzca el telefono";
            }
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Introduzca el Correo")
            {
                txtCorreo.Clear();
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Introduzca el Correo";
            }
        }
    }
}
