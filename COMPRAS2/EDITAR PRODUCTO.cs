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
    public partial class EDITAR_PRODUCTO : Form
    {
        Devices devices;
        public EDITAR_PRODUCTO(Devices devices)
        {
            InitializeComponent();
            this.devices = devices;

        }

        public EDITAR_PRODUCTO()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);

        }

        private void EDITAR_PRODUCTO_Load(object sender, EventArgs e)
        {
            this.txtProducto.Text = devices.producto;
            this.txtCodigoQR.Text = devices.codigo;
            this.txtCompra.Text = devices.compra;
            this.txtMarca.Text = devices.marca;
            this.txtModelo.Text = devices.modelo;
            this.txtCosto.Text = devices.costo.ToString();
            this.txtOrigen.Text = devices.Origen;
            this.txtLugar.Text = devices.Lugar_Actual;
            this.txtEstatus.Text = devices.StatusActual;
            this.txtDescompostura.Text = devices.descompostura;
            this.txtProvedor.Text = devices.proveedor;
            this.txtCantidad.Text = devices.cantidad.ToString();
            this.txtFoto.Text = devices.Foto;
        }
    }
}
