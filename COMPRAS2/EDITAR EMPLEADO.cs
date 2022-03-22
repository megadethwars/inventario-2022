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
    public partial class EDITAR_EMPLEADO : Form
    {
        List<Tuple<Int32, String>> listaRoles;
        User user;
        int id = 0;
        public EDITAR_EMPLEADO(User user)
        {
            InitializeComponent();
            this.user = user;
            listaRoles = new List<Tuple<int, string>>();
            id = user.id;
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async void EDITAR_EMPLEADO_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = user.nombre;
            this.txtCorreo.Text = user.correo;
            this.txtTelefono.Text = user.telefono;
            
            int status = await Roles();           
            this.cbEmpleado.Text = user.rolNombre;
        }

        private async Task<int> Roles()
        {
            try
            {
                var url = HttpMethods.url + "roles";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500)
                {

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

                    listaRoles.Add(Tuple.Create<Int32, String>(roles[x].id, roles[x].nombre));
                }
                cbEmpleado.DataSource = listaRoles;
                cbEmpleado.DisplayMember = "Item2";
                cbEmpleado.ValueMember = "Item1";               

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditarEmpleado();
        }

        private async void EditarEmpleado()
        {
            
            int idEmpleados = 0;
            

            User userUpdate;
            userUpdate = new User();

            userUpdate.nombre = txtNombre.Text;
            userUpdate.correo = txtCorreo.Text;
            userUpdate.telefono = txtTelefono.Text;

            if (cbEmpleado.SelectedItem != null)
            {
                var idEmpleadotuple = (Tuple<int, string>)cbEmpleado.SelectedItem;
                idEmpleados = idEmpleadotuple.Item1;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun estatus");
                return;
            }
            userUpdate.statusId = idEmpleados;            

            Navigator.backPage(this.Name, this);
        }
    }
}
