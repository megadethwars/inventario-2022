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
    public partial class BUSQUEDA_AVANZADA_EMPLEADO : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblBusquedaAvanzada.Font = new Font(ff, 26, fontStyle);
            this.lblNombre.Font = new Font(ff, 20, fontStyle);
            this.lblCorreo.Font = new Font(ff, 20, fontStyle);
            this.label1.Font = new Font(ff, 20, fontStyle);
            this.label2.Font = new Font(ff, 20, fontStyle);
            this.label5.Font = new Font(ff, 20, fontStyle);
            this.label8.Font = new Font(ff, 20, fontStyle);
            this.lblLugares.Font = new Font(ff, 20, fontStyle);
            this.lblEstatus.Font = new Font(ff, 20, fontStyle);
            this.btnLimpiar.Font = new Font(ff, 20, fontStyle);
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

        List<Tuple<Int32, String>> listaEstado;
        List<Tuple<Int32, String>> listaRoles;
        List<User> users;

        public BUSQUEDA_AVANZADA_EMPLEADO(Devices devices)
        {
            InitializeComponent();
            listaEstado = new List<Tuple<int, string>>();
            listaRoles = new List<Tuple<int, string>>();
        }

        private async Task<int> Estado()
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
                    listaEstado.Add(Tuple.Create<Int32, String>(estatus[x].id, estatus[x].descripcion));
                }
                cbEstado.DataSource = listaEstado;
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
                    MessageBox.Show("Estatus no encontrados");
                    return 2;
                }

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }

                var lugares = JsonConvert.DeserializeObject<List<Rol>>(statusmessage.data);

                for (int x = 0; x < lugares.Count; x++)
                {
                    listaRoles.Add(Tuple.Create<Int32, String>(lugares[x].id, lugares[x].nombre));
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

        private async void BUSQUEDA_AVANZADA_EMPLEADO_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            int status = await Estado();
            int roles = await Roles();
            this.cbEstado.Text = null;
            this.cbRoles.Text = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = null;
            this.txtNombre.Text = null;
            this.txtCorreo.Text = null;
            this.txtApellidoPaterno.Text = null;
            this.txtApellidoMaterno.Text = null;
            this.txtTelefono.Text = null;
            this.txtUsuario.Text = null;
            this.cbEstado.Text = null;
            this.cbRoles.Text = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            busqueda();
        }
        
        public async void busqueda()
        {
           int idRoles = 0;
           int idEstatus = 0;

           QueryUsers userquery = new QueryUsers();

           if (txtNombre.Text != "")
           {
                userquery.nombre = txtNombre.Text;
           }

           if (txtCorreo.Text != "")
           {
                userquery.correo = txtCorreo.Text;
           }

           if (txtApellidoPaterno.Text != "")
           {
                userquery.apellidoPaterno = txtApellidoPaterno.Text;
           }

           if (txtApellidoMaterno.Text != "")
           {
                userquery.apellidoMaterno = txtApellidoMaterno.Text;
           }

           if (txtTelefono.Text != "")
           {
                userquery.telefono = txtTelefono.Text;
           }

           if (txtUsuario.Text != "")
           {
                userquery.username = txtUsuario.Text;
           }

           if (cbRoles.SelectedItem != null)
           {
               var idRolestuple = (Tuple<int, string>)cbRoles.SelectedItem;
               idRoles = idRolestuple.Item1;
               if (idRoles != 0)
               {
                    userquery.rolId = idRoles;
               }
           }

           if (cbEstado.SelectedItem != null)
           {
               var idEstadostuple = (Tuple<int, string>)cbEstado.SelectedItem;
               idEstatus = idEstadostuple.Item1;
               if (idEstatus != 0)
               {
                    userquery.statusId = idEstatus;
               }
           }

           string json = JsonConvert.SerializeObject(userquery,
               new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
           var url = HttpMethods.url + "usuarios/query";
           StatusMessage statusmessage = await HttpMethods.Post(url, json);

           if (statusmessage.statuscode == 500)
           {
               MessageBox.Show("Error interno en el servidor");
           }

           if (statusmessage.statuscode == 409)
           {
               MessageBox.Show("Ocurrio un conflicto");
           }

           if (statusmessage.statuscode == 400)
           {
               MessageBox.Show("No hay campos seleccionados a consultar");
           }

           if (statusmessage.statuscode == 404)
           {
               MessageBox.Show("recurso NO encontrado");
           }

           if (statusmessage.statuscode == 200)
           {
               users = JsonConvert.DeserializeObject<List<User>>(statusmessage.data);

               if (users.Count == 0)
               {
                   MessageBox.Show("No hay productos que coinciden con el criterio de busqueda");
                   dgvEmpleado.DataSource = null;
                   return;
               }

               for (int x = 0; x < users.Count; x++)
               {
                    Rol rolNombre = users[x].rol;
                    users[x].rolNombre = rolNombre.nombre;

                    StatusUser statusUserDescripcion = users[x].status;
                    users[x].statusUserDescripcion = statusUserDescripcion.descripcion;
                }

                dgvEmpleado.DataSource = users;

                this.dgvEmpleado.Columns["correo"].Visible = false;
                this.dgvEmpleado.Columns["rolId"].Visible = false;
                this.dgvEmpleado.Columns["foto"].Visible = false;
                this.dgvEmpleado.Columns["statusId"].Visible = false;
                this.dgvEmpleado.Columns["password"].Visible = false;
                this.dgvEmpleado.Columns["rol"].Visible = false;
                this.dgvEmpleado.Columns["statusUserDescripcion"].Visible = false;
                this.dgvEmpleado.Columns["status"].Visible = false;
                this.dgvEmpleado.Columns["id"].Visible = false;
            }
        }

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvEmpleado.Rows[e.RowIndex];
                User data = (User)cell.DataBoundItem;

                Navigator.nextPage(new DETALLES_EMPLEADO(data));

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
