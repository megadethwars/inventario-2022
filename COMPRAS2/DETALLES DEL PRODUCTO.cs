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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace COMPRAS2
{
    public partial class DETALLES_DEL_PRODUCTO : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblTituloEditarProducto.Font = new Font(ff, 26, fontStyle);
            this.lblProducto.Font = new Font(ff, 20, fontStyle);
            this.lblCodigoQR.Font = new Font(ff, 20, fontStyle);
            this.lblCompra.Font = new Font(ff, 20, fontStyle);
            this.lblMarca.Font = new Font(ff, 20, fontStyle);
            this.lblModelo.Font = new Font(ff, 20, fontStyle);
            this.lblCosto.Font = new Font(ff, 20, fontStyle);
            this.lblOrigen.Font = new Font(ff, 20, fontStyle);
            this.label4.Font = new Font(ff, 20, fontStyle);
            this.lblLugar.Font = new Font(ff, 20, fontStyle);
            this.lblFechaDeModificacion.Font = new Font(ff, 20, fontStyle);
            this.lblEstatus.Font = new Font(ff, 20, fontStyle);
            this.lblDescompostura.Font = new Font(ff, 20, fontStyle);
            this.lblDescompostura.Font = new Font(ff, 20, fontStyle);
            this.lblProvedor.Font = new Font(ff, 20, fontStyle);
            this.lblCantidad.Font = new Font(ff, 20, fontStyle);
            this.lblFecha.Font = new Font(ff, 20, fontStyle);
            this.lblAccesorio.Font = new Font(ff, 20, fontStyle);
            this.label2.Font = new Font(ff, 20, fontStyle);
            this.btnEditar.Font = new Font(ff, 18, fontStyle);
            this.btnELIMINAR.Font = new Font(ff, 18, fontStyle);
            this.lblCREAR_REPORTE.Font = new Font(ff, 18, fontStyle);
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

        Devices devices;
        List<Devices> listDevices = new List<Devices>();
        string codigo = "";
        public DETALLES_DEL_PRODUCTO(string codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
        }

        public void brnOPCIONES_Click(object sender, EventArgs e)
        {
            try
            {
                this.devices = devices;
                Navigator.nextPage(new EDITAR_PRODUCTO(devices));
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async void DETALLES_DEL_PRODUCTO_Load(object sender, EventArgs e)
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
            listDevices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);
            if (listDevices.Count == 0)
            {
                return;
            }
            devices = listDevices[0];

            this.lblDProducto.Text = listDevices[0].producto;
            this.lblDCompra.Text = listDevices[0].compra;
            this.lblDCodigoQR.Text = listDevices[0].codigo;
            this.lblDMarca.Text = listDevices[0].marca;
            this.lblDModelo.Text = listDevices[0].modelo;
            this.lblDCosto.Text = listDevices[0].costo.ToString();
            this.lblDOrigen.Text = listDevices[0].origen;
            this.lblDFecha.Text = listDevices[0].fechaAlta.ToString();
            this.lblDModFecha.Text = listDevices[0].fechaUltimaModificacion.ToString();
            this.lblDLugar.Text = listDevices[0].Lugar_Actual;
            this.lblDEstatus.Text = listDevices[0].StatusActual;
            this.lblDDescompostura.Text = listDevices[0].descompostura;
            this.lblDProvedor.Text = listDevices[0].proveedor;
            this.lblDCantidad.Text = listDevices[0].cantidad.ToString();
            this.lblDAccesorio.Text = listDevices[0].accesorios;
            this.lblObservaciones.Text = listDevices[0].observaciones;
            this.lblSerie.Text = listDevices[0].serie;

            
        }

        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea eliminar a este producto?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EliminarProducto();
            }
                       
        }

        private async void EliminarProducto()
        {
                       
            Devices devicesUpdate;
            devicesUpdate = new Devices();

            devicesUpdate.id = devices.id;
            devicesUpdate.statusId = 2;

            
            string json = JsonConvert.SerializeObject(devicesUpdate,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos";
            StatusMessage statusmessage = await HttpMethods.put(url, json);

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("error en el servicio, " + statusmessage.message);
                return;
            }

            else if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("error en el servicio");
                return;
            }
            else if (statusmessage.statuscode == 200)
            {
                Devices USERS = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                MessageBox.Show("PRODUCTO ELIMINADO");
                Navigator.backPage(this.Name, this);
                return;
            }
            else if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("error en el servicio, NO encontrado");

                return;
            }
            else
            {
                MessageBox.Show("Bad request, algunos campos faltantes");
                return;
            }

            Navigator.backPage(this.Name, this);
        }

        private void lblCREAR_REPORTE_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new REPORTES());
        }
    }
}
