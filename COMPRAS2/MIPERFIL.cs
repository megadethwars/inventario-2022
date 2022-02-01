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
    public partial class MIPERFIL : Form
    {
        string url = "https://avsinventoryswagger.azurewebsites.net/api/v1/";
        public MIPERFIL()
        {
            InitializeComponent();
        }

        private void MIPERFIL_Load(object sender, EventArgs e)
        {
            var url = HttpMethods.url + "usuarios";
            //StatusMessage
        }
    }
}
