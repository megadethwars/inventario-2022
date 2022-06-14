﻿using COMPRAS2.modelos;
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
    public partial class SALIDA : Form
    {
        public List<Devices> devices;
        public List<Movimientos> movimientos;
        public SALIDA()
        {
            InitializeComponent();
            devices = new List<Devices>();
            movimientos = new List<Movimientos>();
        }

        private void bTNBack_Click(object sender, EventArgs e)
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

        public async void busqueda() {

            //busqueda
            if (txtBUSCADOR.Text == "") {
                MessageBox.Show("Campo de Texto vacio");
                return;          
            }

            QueryDevice devicequery = new QueryDevice();
            devicequery.codigo = txtBUSCADOR.Text;

            string json = JsonConvert.SerializeObject(devicequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos/query";
            StatusMessage statusmessage = await HttpMethods.Post(url,json);

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

                if (devices.Count == 0)
                {
                    MessageBox.Show("No hay dispositivos en stock, cantidad Insuficiente");
                    return;
                }
                this.lbNombre.Text = devices[0].producto;
                this.lbOrigen.Text = devices[0].origen;
                this.lbSerie.Text = "N/A";
                this.lbCantitad.Text = devices[0].cantidad_de_productos.ToString();
                this.lbMarca.Text = devices[0].marca;
                this.lbdesc.Text = devices[0].descompostura;              

                Agregar(devices[0]);

            }

        }

        private void Agregar(Devices device) {
            //convert device to movement
            Movimientos movement = new Movimientos();
            movement.usuarioId = CurrentUsers.id;
            movement.dispositivoId = device.id;
            movement.dispositivo = device;                        
            movement.tipoMovId = 1;
            bool deviceExist = movimientos.Any(x => x.dispositivoId == device.id && x.dispositivoId == device.id);
            if (deviceExist) {
                MessageBox.Show("el producto ya existe en la lista");
                return;
            }
            movimientos.Add(movement);           
        }
        

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (movimientos.Count == 0) {
                MessageBox.Show("No hay productos para realizar una salida");
                return;
            }
            Navigator.nextPage(new CarritoSalida(this));
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
