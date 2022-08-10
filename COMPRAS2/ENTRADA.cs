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
    public partial class ENTRADA : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblCarritoDeSalida.Font = new Font(ff, 26, fontStyle);
            this.lblProducto.Font = new Font(ff, 20, fontStyle);
            this.lbS.Font = new Font(ff, 20, fontStyle);
            this.or.Font = new Font(ff, 20, fontStyle);
            this.lbd.Font = new Font(ff, 20, fontStyle);
            this.lbm.Font = new Font(ff, 20, fontStyle);
            this.mod.Font = new Font(ff, 20, fontStyle);
            this.label3.Font = new Font(ff, 20, fontStyle);
            this.btClear.Font = new Font(ff, 18, fontStyle);
            this.btnAgregarCarrito.Font = new Font(ff, 18, fontStyle);
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

        public List<Devices> devices;
        public List<Movimientos> movimientos;

        string sameIdmovimiento="";
        string currentSameIdmovimiento = "";
        bool isFirst = false;
        public ENTRADA()
        {
            InitializeComponent();

            devices = new List<Devices>();
            movimientos = new List<Movimientos>();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                busqueda();
            }
        }

        public async Task<string> idMovement(int idDevice) {

            try
            {
                var url = HttpMethods.url + "movimientos/LastOne/"+idDevice.ToString();
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno en el servidor al consultar n movimiento");
                }

                if (statusmessage.statuscode == 409)
                {
                    MessageBox.Show("Ocurrio un conflicto al consultar un movimiento Previo");
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("recurso NO encontrado");
                }

                if (statusmessage.statuscode == 200)
                {
                    var movimiento = JsonConvert.DeserializeObject<Movimientos>(statusmessage.data);

                    sameIdmovimiento = movimiento.idMovimiento;
                }
            }
            catch (Exception ex)
            {

            }
            return sameIdmovimiento;
        }

        public async void busqueda()
        {
            //busqueda
            if (txtBUSCADOR.Text == "")
            {
                MessageBox.Show("Campo de Texto vacio");
                return;
            }

            QueryDevice devicequery = new QueryDevice();
            devicequery.codigo = txtBUSCADOR.Text;

            string json = JsonConvert.SerializeObject(devicequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos/query";
            StatusMessage statusmessage = await HttpMethods.Post(url, json);

            if (statusmessage.statuscode == 500)
            {
                MessageBox.Show("Error interno en el servidor");
            }

            if (statusmessage.statuscode == 409)
            {
                MessageBox.Show("Ocurrio un conflicto");
            }

            if (statusmessage.statuscode == 404)
            {
                MessageBox.Show("recurso NO encontrado");
            }

            if (statusmessage.statuscode == 200)
            {
                devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                //validate if data is NOT in almacen
                if (devices.Count == 0) {
                    MessageBox.Show("El dipositivo NO existe");
                    return;
                }
                if (devices[0].lugarId == 1)
                {
                    MessageBox.Show("El dipositivo YA se encuentra en almacen");
                    return;
                }

                /*
                sameIdmovimiento = await idMovement(devices[0].id);

                if (sameIdmovimiento == "") {

                    MessageBox.Show("Vuelva a repetir el proceso, ha ocurrido un error en los movimientos");

                    return;
                }
                */

                /*
                if (isFirst) {
                    if (sameIdmovimiento != currentSameIdmovimiento) {
                        MessageBox.Show("El dipositivo no pertenece al mismo movimiento");
                        return;
                    }
                }
                */

                this.lbNombre.Text = devices[0].producto;
                this.lbOrigen.Text = devices[0].origen;
                this.lbSerie.Text = devices[0].serie;
                this.lbCantitad.Text = devices[0].cantidad.ToString();
                this.lbMarca.Text = devices[0].marca;
                this.lbdesc.Text = devices[0].descompostura;
                this.lbModelo.Text = devices[0].modelo;              

                //llenar

                Agregar(devices[0]);
                currentSameIdmovimiento = sameIdmovimiento;
                isFirst = true;
            }
        }

        private void Agregar(Devices device)
        {
            //convert device to movement
            Movimientos movement = new Movimientos();
            movement.usuarioId = CurrentUsers.id;
            movement.dispositivoId = device.id;
            movement.dispositivo = device;
            movement.tipoMovId = 2;
            bool deviceExist = movimientos.Any(x => x.dispositivoId == device.id && x.dispositivoId == device.id);
            if (deviceExist)
            {
                MessageBox.Show("el producto ya existe en la lista");
                return;
            }
            movimientos.Add(movement);
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (movimientos.Count == 0)
            {
                MessageBox.Show("No hay productos para realizar una entrada");
                return;
            }
            Navigator.nextPage(new CarritoEntrada(this));
        }

        private void ENTRADA_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            isFirst = false;
            movimientos.Clear();

            this.lbNombre.Text = "Por definir";
            this.lbOrigen.Text = "Por definir";
            this.lbSerie.Text = "Por definir";
            this.lbCantitad.Text = "Por definir";
            this.lbMarca.Text = "Por definir";
            this.lbdesc.Text = "Por definir";
            this.lbModelo.Text = "Por definir";
        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            txtBUSCADOR.Clear();
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            busqueda();
        }
    }
}
