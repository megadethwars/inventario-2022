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

        private void SPECIALBUTTON_Click(object sender, EventArgs e)
        {
            MENU menu = new MENU();
            menu.Show();
            this.Hide();
        }
        
        private void USERID_Leave(object sender, EventArgs e)
        {
            if (USERID.Text == "")
            {
                USERID.Text = "USER ID";
                USERID.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }

        private void PASSWORD_Leave(object sender, EventArgs e)
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
    }
}
