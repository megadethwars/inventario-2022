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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace COMPRAS2
{
    public partial class AJUSTES : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblPerfil.Font = new Font(ff, 26, fontStyle);
            this.lblCopiaDeSeguridad.Font = new Font(ff, 20, fontStyle);
            this.lblSincronizacionAutomatica.Font = new Font(ff, 20, fontStyle);
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

        public AJUSTES()
        {
            InitializeComponent();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void linkInformacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Aqui informacion de la aplicacion");
        }

        private void AJUSTES_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            try
            {

            }
            catch
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }
    }
}
