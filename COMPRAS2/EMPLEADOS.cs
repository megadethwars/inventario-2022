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
    public partial class EMPLEADOS : Form
    {
        public  EMPLEADOS()
        {
            InitializeComponent();
            
        }        

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async Task<int> empleados()
        {
            try
            {
                var url = HttpMethods.url + "usuarios";
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200)
                {
                    return 1;
                }

                List<User> user = JsonConvert.DeserializeObject<List<User>>(statusmessage.data);
                for (int x = 0; x < user.Count; x++)
                {
                    Rol rolNombre = user[x].rol;                   
                    user[x].rolNombre = rolNombre.nombre;

                    StatusUser statusUserDescripcion = user[x].status;
                    user[x].statusUserDescripcion = statusUserDescripcion.descripcion;
                    
                }
                

                dgvUsuarios.DataSource = user;
                this.dgvUsuarios.Columns["correo"].Visible = false;
                this.dgvUsuarios.Columns["rolId"].Visible = false;
                this.dgvUsuarios.Columns["foto"].Visible = false;
                this.dgvUsuarios.Columns["statusId"].Visible = false;
                this.dgvUsuarios.Columns["password"].Visible = false;
                this.dgvUsuarios.Columns["rol"].Visible = false;
                this.dgvUsuarios.Columns["statusUserDescripcion"].Visible = false;
                this.dgvUsuarios.Columns["status"].Visible = false;
                this.dgvUsuarios.Columns["id"].Visible = false;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
                return 10;
            }
        }

        private async void EMPLEADOS_Load(object sender, EventArgs e)
        {
            
            try
            {
                if(CurrentUsers.rol.id != 1)
                {
                   btAgregarEmp.Enabled = false;
                }
                await empleados();
            }
            catch
            {
                MessageBox.Show("Navegue con mas lentitud");
            }          
        }

        public void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {               
                DataGridViewRow cell = dgvUsuarios.Rows[e.RowIndex];
                User data = (User)cell.DataBoundItem;

                Navigator.nextPage(new DETALLES_EMPLEADO(data));
                
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btAgregarEmp_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new AGREGAR_EMPLEADO());
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = null;
            await empleados();
        }

        private void dgvUsuarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        Devices devices;
        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            this.devices = devices;
            Navigator.nextPage(new BUSQUEDA_AVANZADA_EMPLEADO(devices));
        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            
        }
    }
}
