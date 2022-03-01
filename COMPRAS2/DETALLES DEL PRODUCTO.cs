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

        private void brnOPCIONES_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new EDITAR_PRODUCTO());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void DETALLES_DEL_PRODUCTO_Load(object sender, EventArgs e)
        {
            
            this.lblDProducto.Text = devices.Producto;
            this.lblDCompra.Text = devices.Compra;
            this.lblDCodigoQR.Text = devices.Codigo;
            this.lblDMarca.Text = devices.Marca;
            this.lblDModelo.Text = devices.Modelo;
            this.lblDCosto.Text = devices.Costo.ToString();
            this.lblDOrigen.Text = devices.Origen;
            this.lblDFecha.Text = devices.FechaAlta.ToString();
            //this.lblDLugar.Text = devices.Lugar_Actual.ToString();            
            this.lblDDescompostura.Text = devices.Descompostura;
            this.lblDProvedor.Text = devices.Proveedor;


        }
    }
}
