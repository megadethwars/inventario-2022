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
using System.Runtime.InteropServices;
using System.Drawing.Text;
using Newtonsoft.Json;

namespace COMPRAS2
{
    public partial class DETALLES_HISTORIAL : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblDETALLES.Font = new Font(ff, 26, fontStyle);
            this.lblDCodigo.Font = new Font(ff, 20, fontStyle);
            this.lblDUsuario.Font = new Font(ff, 20, fontStyle);
            this.lblDProducto.Font = new Font(ff, 20, fontStyle);
            this.lblDIdMovimiento.Font = new Font(ff, 20, fontStyle);
            this.lblDTipoDeMovimiento.Font = new Font(ff, 20, fontStyle);
            this.lblDFecha.Font = new Font(ff, 20, fontStyle);
            this.lblDLugar.Font = new Font(ff, 20, fontStyle);        
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

        Movimientos movi;
        List<Movimientos> listMovi = new List<Movimientos>();
        string codigo = "";

        Movimientos mov;
        public DETALLES_HISTORIAL(string codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async void DETALLES_HISTORIAL_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            QueryDevice devicequery = new QueryDevice();
            devicequery.codigo = this.codigo;
            int page = 1;
            string url = "";
            string json = JsonConvert.SerializeObject(devicequery,
            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });

            url = HttpMethods.url + "dispositivos/query?offset=" + page.ToString() + "&limit=30";


            StatusMessage statusmessage = await HttpMethods.Post(url, json);
            listMovi = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);
            if (listMovi.Count == 0)
            {
                return;
            }
            movi = listMovi[0];

            this.lblUsuario.Text = mov.nombre_Actual;
            this.lblCodigo.Text = mov.codigo_Actual;
            this.lblProducto.Text = mov.dispositivo_Actual;
            this.lblIdMovimiento.Text = mov.idMovimiento;
            this.lblTipoDeMovimiento.Text = mov.tipo_Actual;
            this.lblFecha.Text = mov.fechaAlta.ToString();
        }
    }
}
