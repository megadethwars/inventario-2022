using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMPRAS2.servicios;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace COMPRAS2
{
    public  partial class MENU : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        
        private void CargoEtiqueta(Font font)
        {           
            FontStyle fontStyle = FontStyle.Regular;

            this.btnPerfil.Font = new Font(ff, 22, fontStyle);
            this.btnCerrarSesion.Font = new Font(ff, 22, fontStyle);
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

        MENU2 mainmenu;
        public int a = 0;
        public MENU()
        {
            mainmenu = new MENU2(this);
            InitializeComponent();
            Navigator.setMainMenu(this);
            Navigator.setMainMenuoPT(mainmenu);
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);
            Navigator.nextPage(mainmenu);
            //AbrirFormHija(mainmenu);
        }

        private void MENU_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.PANELCONTENEDOR.Controls.Count > 0)
                this.PANELCONTENEDOR.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PANELCONTENEDOR.Controls.Add(fh);
            this.PANELCONTENEDOR.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)

        {

            int count = this.PANELCONTENEDOR.Controls.Count;
            string name = "";
            if (count > 1)
            {
                string[] names = new string [count - 1];
                int temp = 0;
                foreach (Control control in this.PANELCONTENEDOR.Controls)
                {
                    if (control.Name != mainmenu.Name) {

                        names[temp] = control.Name;
                        temp++;
                    }
                    
                }

                foreach (string nm in names) {

                    Control[] controls = this.PANELCONTENEDOR.Controls.Find(nm, true);

                    foreach (Control ctl in controls) {
                        this.PANELCONTENEDOR.Controls.RemoveByKey(nm);

                        ctl.Dispose();
                    }

                }

                Control[] controlsUnique = this.PANELCONTENEDOR.Controls.Find(mainmenu.Name, true);

                foreach (Control ctrl in controlsUnique)
                {
                    ctrl.Show();
                }
            }
            else
            {
                return;
            }         
        }
      
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            INICIARSESION iniciarsesion = new INICIARSESION();
            iniciarsesion.Show();
            this.Dispose();
        }
        
        private void PANELCONTENEDOR_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
