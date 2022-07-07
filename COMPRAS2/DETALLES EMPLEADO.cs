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
    public partial class DETALLES_EMPLEADO : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.INVENTARIOTITLE.Font = new Font(ff, 26, fontStyle);
            this.lblDNombreDelEmpleado.Font = new Font(ff, 20, fontStyle);
            this.lblDFechaDeIngreso.Font = new Font(ff, 20, fontStyle);
            this.lblDTipoDeUsuario.Font = new Font(ff, 20, fontStyle);
            this.lblDEstadoDelUsuario.Font = new Font(ff, 20, fontStyle);
            this.lblDCorreo.Font = new Font(ff, 20, fontStyle);
            this.lblDTelefono.Font = new Font(ff, 20, fontStyle);
            this.btnEditar.Font = new Font(ff, 18, fontStyle);
            this.btnContraseña.Font = new Font(ff, 18, fontStyle);
            this.btnEliminar.Font = new Font(ff, 18, fontStyle);
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
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

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
            if (MessageBox.Show("¿Seguro que desea eliminar a este empleado?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EliminarEmpleado();
            }
            
        }

        private async void EliminarEmpleado()
        {
            
            User userUpdate;
            userUpdate = new User();

            userUpdate.id = user.id;
            userUpdate.statusId = 2;
            
                        
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

            Navigator.backPage(this.Name, this);
        }
    }
}
