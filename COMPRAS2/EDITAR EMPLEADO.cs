using COMPRAS2.modelos;
using COMPRAS2.servicios;
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
        public EDITAR_EMPLEADO(User user)
        {
            InitializeComponent();
            this.user = user;
            listaRoles = new List<Tuple<int, string>>();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void EDITAR_EMPLEADO_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = user.nombre;
            this.txtCorreo.Text = user.correo;
            this.txtTelefono.Text = user.telefono;
            //cbEmpleado.DataSource
        }
    }
}
