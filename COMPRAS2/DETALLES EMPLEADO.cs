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
    public partial class DETALLES_EMPLEADO : Form
    {
        User user;
        public DETALLES_EMPLEADO(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        public void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //this.user = user;
                Navigator.nextPage(new EDITAR_EMPLEADO(user));
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);          
        }

        private void DETALLES_EMPLEADO_Load(object sender, EventArgs e)
        {
            if (CurrentUsers.rol.id != 1)
            {
                btnEditar.Enabled = false;
                btnContraseña.Enabled = false;
                btnEliminar.Enabled = false;               
            }

            if(CurrentUsers.rol.id == user.id)
            {
                btnEliminar.Enabled = false;
            }
            lblNombreDelEmpleado.Text = user.nombre + " " + user.apellidoPaterno + " " + user.apellidoMaterno;
            lblFechaDeIngreso.Text = user.fechaAlta.ToString();
            lblTipoDeUsuario.Text = user.rolNombre;
            lblEstadoDelUsuario.Text = user.statusUserDescripcion;
            lblCorreo.Text = user.correo;
            lblTelefono.Text = user.telefono;
        }

        private void btnContraseña_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new CAMBIAR_CONTRASEÑA_EMPLEADOS(user));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Seguro que desea eliminar a este empleado?");
            EliminarEmpleado();
        }

        private async void EliminarEmpleado()
        {
            
            User userUpdate;
            userUpdate = new User();

            userUpdate.id = 3;
            userUpdate.statusId = 3;
            

            /*
            userUpdate.statusId = idEstado;

            userUpdate.id = id;
            */
            

            string json = JsonConvert.SerializeObject(userUpdate,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "usuarios";
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
                User USERS = JsonConvert.DeserializeObject<User>(statusmessage.data);
                MessageBox.Show("EMPLEADO ELIMINADO");
                Navigator.nextPage(new EMPLEADOS());
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

            Navigator.nextPage(new EMPLEADOS());
        }
    }
}
