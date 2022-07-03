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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace COMPRAS2
{
    public partial class AGREGAR_EMPLEADO : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblREPORTES.Font = new Font(ff, 26, fontStyle);
            this.lblProvedor.Font = new Font(ff, 20, fontStyle);
            this.label1.Font = new Font(ff, 20, fontStyle);
            this.label2.Font = new Font(ff, 20, fontStyle);
            this.label8.Font = new Font(ff, 20, fontStyle);
            this.label3.Font = new Font(ff, 20, fontStyle);
            this.label4.Font = new Font(ff, 20, fontStyle);
            this.label5.Font = new Font(ff, 20, fontStyle);
            this.label6.Font = new Font(ff, 20, fontStyle);
            this.label7.Font = new Font(ff, 20, fontStyle);
            this.lblEstadoDelUsuario.Font = new Font(ff, 20, fontStyle);
        }

        private void CargoPrivateFontCollection()
        {
            // CREO EL BYTE[] Y TOMO SU LONGITUD
            byte[] fontArray = COMPRAS2.Properties.Resources.Knockout_48;
            int dataLength = COMPRAS2.Properties.Resources.Knockout_48.Length;

            // ASIGNO MEMORIA Y COPIO BYTE[] EN LA DIRECCION
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASO LA FUENTE A LA PRIVATEFONTCOLLECTION
            pfc.AddMemoryFont(ptrData, dataLength);

            //LIBERO LA MEMORIA "UNSAFE"
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }

        List<Tuple<Int32, String>> listaRoles;
        List<Tuple<Int32, String>> listaStatus;

        public AGREGAR_EMPLEADO()
        {
            InitializeComponent();
            listaRoles = new List<Tuple<int, string>>();
            listaStatus = new List<Tuple<int, string>>();
        }

        private async void AGREGAR_EMPLEADO_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            int roles = await Roles();
            int estatus = await Estatus();
            this.cbRoles.Text = null;
            this.cbEstado.Text = null;
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

        private async Task<int> Estatus()
        {
            try
            {
                var url = HttpMethods.url + "statusUsuarios";
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

                var estatus = JsonConvert.DeserializeObject<List<StatusUser>>(statusmessage.data);

                for (int x = 0; x < estatus.Count; x++)
                {
                    listaStatus.Add(Tuple.Create<Int32, String>(estatus[x].id, estatus[x].descripcion));
                }

                listaStatus.RemoveAt(2);

                cbEstado.DataSource = listaStatus;
                cbEstado.DisplayMember = "Item2";
                cbEstado.ValueMember = "Item1";

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
                Int32 cantidad = 0;
                //Int32 costo = 0;
                int idRol = 0;
                int idEstatus = 0;
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

                if (textUsuario.Text == "")
                {
                    MessageBox.Show("campo de usuario esta vacio");
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
                    MessageBox.Show("campo de telefono vacio");
                    return 1;
                }

                try
                {
                    cantidad = Int32.Parse(txtTelefono.Text);
                }
                catch
                {
                    MessageBox.Show("El telefono no es numerico");
                    return 1;
                }

                if (cbRoles.SelectedItem != null)
                {
                    var idRoltuple =(Tuple<int, string>)cbRoles.SelectedItem;
                    idRol = idRoltuple.Item1;
                }else
                {
                    MessageBox.Show("No se ha seleccionado ningun estado");
                    return 1;
                }

                if (cbEstado.SelectedItem != null)
                {
                    var idEstatustuple = (Tuple<int, string>)cbEstado.SelectedItem;
                    idEstatus = idEstatustuple.Item1;
                }else 
                {
                    MessageBox.Show("No se ha seleccionado ningun estado");
                    return 1;
                }

                
                if (txtContraseña.Text != txtContraseñaDeNuevo.Text) {
                    MessageBox.Show("Error en las contraseñas, intenta de nuevo");
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
                user.statusId = idEstatus;
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

        private void txtContraseña_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;            
        }       

        private void txtContraseñaDeNuevo_Click(object sender, EventArgs e)
        {
            txtContraseñaDeNuevo.UseSystemPasswordChar = true;           
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

        private void txtApellidoMaterno_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtContraseña.Clear();
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtContraseñaDeNuevo.Clear();
                txtContraseñaDeNuevo.UseSystemPasswordChar = true;
            }
        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
