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
        public DETALLES_DEL_PRODUCTO(Devices devices)
        {
            InitializeComponent();
            this.devices = devices;           
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

        private void DETALLES_DEL_PRODUCTO_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            this.lblDProducto.Text = devices.producto;
            this.lblDCompra.Text = devices.compra;
            this.lblDCodigoQR.Text = devices.codigo;
            this.lblDMarca.Text = devices.marca;
            this.lblDModelo.Text = devices.modelo;
            this.lblDCosto.Text = devices.costo.ToString();
            this.lblDOrigen.Text = devices.origen;
            this.lblDFecha.Text = devices.fechaAlta.ToString();
            this.lblDModFecha.Text = devices.fechaUltimaModificacion.ToString();
            this.lblDLugar.Text = devices.Lugar_Actual;
            this.lblDEstatus.Text = devices.StatusActual;            
            this.lblDDescompostura.Text = devices.descompostura;
            this.lblDProvedor.Text = devices.proveedor;
            this.lblDCantidad.Text = devices.cantidad.ToString();
            this.lblDAccesorio.Text = devices.accesorios;
            this.lblObservaciones.Text = devices.observaciones;
            this.lblSerie.Text = devices.serie;
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
