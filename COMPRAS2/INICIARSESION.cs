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
using COMPRAS2.modelos;
using Newtonsoft.Json;
using COMPRAS2.servicios;
using Newtonsoft.Json.Converters;

namespace COMPRAS2
{
    public partial class INICIARSESION : Form
    {
        public INICIARSESION()
        {
            InitializeComponent();
        }

        private void btnCERRAR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 

        private void btnMIN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,0xf012, 0);
        }


        private async Task<int> Auth()
        {
            try
            {
                if (USERID.Text == "")
                {
                    MessageBox.Show("campo de usuario vacio");
                    return 1;
                }

                if (PASSWORD.Text == "")
                {
                    MessageBox.Show("campo de password vacio");
                    return 1;
                }

                modelos.User user = new User();
                user.username = USERID.Text;
                user.password = PASSWORD.Text;
                user.id = 0;
                user.rolId = 0;
                user.nombre = null;
                user.statusId = 0;
                user.telefono = null;
                user.correo = null;
          
             

                string json = JsonConvert.SerializeObject(user,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore});
                var url = HttpMethods.url + "usuarios/login";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);

                if (statusmessage.statuscode != 201)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                    return 2;
                }

                User userDeserialize = JsonConvert.DeserializeObject<User>(statusmessage.data, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.SSSSSSz" });

                CurrentUser.username = userDeserialize.username;
                CurrentUser.nombre = userDeserialize.nombre;
                CurrentUser.apellidoPaterno = userDeserialize.apellidoPaterno;
                CurrentUser.apellidoMaterno = userDeserialize.apellidoMaterno;
                CurrentUser.correo = userDeserialize.correo;
                CurrentUser.telefono = userDeserialize.telefono;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }

        }

        private void USERID_Leave(object sender, EventArgs e)
        {
            if (USERID.Text == "")
            {
                USERID.Text = "USER ID";
                USERID.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }

        public void PASSWORD_Leave(object sender, EventArgs e)
        {
            if (PASSWORD.Text == "")
            {
                PASSWORD.UseSystemPasswordChar = false;
                PASSWORD.Text = "PASSWORD";
                PASSWORD.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }
        
        private void USERID_Click(object sender, EventArgs e)
        {
            USERID.Clear();
        }

        private void PASSWORD_Click(object sender, EventArgs e)
        {
            PASSWORD.Clear();
            PASSWORD.UseSystemPasswordChar = true;
        }

        private async void btnSingIn_Click(object sender, EventArgs e)
        {
            int status = await Auth();
            if (status == 0)
            {
                MENU menu = new MENU();
                menu.Show();
                this.Hide();
            }
        }
    }
}
