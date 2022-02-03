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
    public partial class ejemplo : Form
    {

        MENU mainmenu;
        INVENTARIO inv;

        public ejemplo(INVENTARIO inv,MENU mainmenu)
        {
            InitializeComponent();
            this.mainmenu = new MENU();
            this.inv = new INVENTARIO(mainmenu);
        }

        private void AbrirFormHija(object formhija)
        {


            if (this.mainmenu.PANELCONTENEDOR.Controls.Count > 0)
                this.mainmenu.PANELCONTENEDOR.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mainmenu.PANELCONTENEDOR.Controls.Add(fh);
            this.mainmenu.PANELCONTENEDOR.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            AbrirFormHija(new INVENTARIO(mainmenu));
        }
    }
}
