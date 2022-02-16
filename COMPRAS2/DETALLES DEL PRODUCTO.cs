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
    public partial class DETALLES_DEL_PRODUCTO : Form
    {
        public DETALLES_DEL_PRODUCTO()
        {
            InitializeComponent();
        }

        private void brnOPCIONES_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new EDITAR_PRODUCTO());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }
    }
}
