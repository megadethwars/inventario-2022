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
    public partial class DETALLES_DEL_PRODUCTO : Form
    {
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
            
            this.lblDProducto.Text = devices.producto;
            this.lblDCompra.Text = devices.compra;
            this.lblDCodigoQR.Text = devices.codigo;
            this.lblDMarca.Text = devices.marca;
            this.lblDModelo.Text = devices.modelo;
            this.lblDCosto.Text = devices.costo.ToString();
            this.lblDOrigen.Text = devices.origen;
            this.lblDFecha.Text = devices.fechaAlta.ToString();
            this.lblDLugar.Text = devices.Lugar_Actual;
            this.lblDEstatus.Text = devices.StatusActual;
            this.lblDDescompostura.Text = devices.descompostura;
            this.lblDProvedor.Text = devices.proveedor;
            this.lblDCantidad.Text = devices.cantidad.ToString();
            this.lblDFoto.Text = devices.foto;
        }
    }
}
