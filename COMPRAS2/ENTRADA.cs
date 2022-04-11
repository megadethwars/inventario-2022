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

namespace COMPRAS2
{
    public partial class ENTRADA : Form
    {

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
                this.lbSerie.Text = "N/A";
                this.lbCantitad.Text = devices[0].cantidad.ToString();
                this.lbMarca.Text = devices[0].marca;
                this.lbdesc.Text = devices[0].descompostura;

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
            movement.tipoMovId = 1;

            movimientos.Add(movement);
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {

        }

        private void ENTRADA_Load(object sender, EventArgs e)
        {

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            isFirst = false;
            movimientos.Clear();

            this.lbNombre.Text = "";
            this.lbOrigen.Text = "";
            this.lbSerie.Text = "";
            this.lbCantitad.Text = "";
            this.lbMarca.Text = "";
            this.lbdesc.Text = "";
        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            txtBUSCADOR.Clear();
        }
    }
}
