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
    public partial class CAMBIAR_CONTRASEÑA_EMPLEADOS : Form
    {
        User user;
        int id = 0;
        public CAMBIAR_CONTRASEÑA_EMPLEADOS(User user)
        {
            InitializeComponent();
            this.user = user;
            id = user.id;
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditarContraseña();
        }
        
        private async void EditarContraseña()
        {           
            User userUpdate;
            userUpdate = new User();

            userUpdate.password = txtContraseña.Text;
            
            
            if(txtContraseña.Text != txtContraseñaDeNuevo.Text)
            {
                MessageBox.Show("LAS CONTRASEÑAS NO SON IGUALES, INTENTE DE NUEVO");
                return;
            }

            userUpdate.id = id;

            userUpdate.statusId = 0;
            userUpdate.rolId = 0;

            userUpdate.username = user.username;
            

            string json = JsonConvert.SerializeObject(userUpdate,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "usuarios/pass";
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
            else if (statusmessage.statuscode == 201)
            {
                User USERS = JsonConvert.DeserializeObject<User>(statusmessage.data);
                MessageBox.Show("EMPLEADO ACTUALIZADO CORRECTAMENTE");
                Navigator.backPage(this.Name, this);
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
        
        private void CAMBIAR_CONTRASEÑA_EMPLEADOS_Load(object sender, EventArgs e)
        {
            txtContraseña.Clear();
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseñaDeNuevo.Clear();
            txtContraseñaDeNuevo.UseSystemPasswordChar = true;
            
            this.lblEmpleado.Text ="USUARIO: " + user.nombre + " " + user.apellidoPaterno + " " + user.apellidoMaterno;
        }
    }
}
