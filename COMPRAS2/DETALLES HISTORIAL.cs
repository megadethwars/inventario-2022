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
    public partial class DETALLES_HISTORIAL : Form
    {
        Movimientos mov;
        public DETALLES_HISTORIAL(Movimientos mov)
        {
            InitializeComponent();
            this.mov = mov;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void DETALLES_HISTORIAL_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = mov.nombre_Actual;
            lblCodigo.Text = mov.codigo_Actual;
            lblProducto.Text = mov.dispositivo_Actual;
            lblIdMovimiento.Text = mov.idMovimiento;
            lblTipoDeMovimiento.Text = mov.tipo_Actual;
            lblFecha.Text = mov.fechaAlta.ToString();
            //lblLugar.Text = 
        }
    }
}
