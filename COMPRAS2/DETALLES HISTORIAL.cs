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
        public DETALLES_HISTORIAL()
        {
            InitializeComponent();
            this.mov = mov;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }
    }
}
