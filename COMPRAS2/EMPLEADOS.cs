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

                var products = JsonConvert.DeserializeObject<List<User>>(statusmessage.data);

                for (int x = 0; x < products.Count; x++)
                {

                    
                }

                dgvUsuarios.DataSource = products;
                this.dgvUsuarios.Columns["correo"].Visible = false;
                this.dgvUsuarios.Columns["rolId"].Visible = false;
                this.dgvUsuarios.Columns["foto"].Visible = false;
                this.dgvUsuarios.Columns["statusId"].Visible = false;

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
            await empleados();

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {/*
                DataGridViewRow cell = dgvInventario.Rows[e.RowIndex];
                Devices data = (Devices)cell.DataBoundItem;*/

                Navigator.nextPage(new DETALLES_EMPLEADO());
                
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
