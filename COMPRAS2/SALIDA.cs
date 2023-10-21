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
using System.Threading;

namespace COMPRAS2
{
    public partial class SALIDA : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        int count = 0;
        DataGridViewButtonColumn btnclm;
        List<Tuple<Int32, String>> listaLugares;
        Lugares lugar =  new Lugares();
        List<String> codigos = new List<String>();
        List<Devices> devices = new List<Devices>();
        public List<DeviceSomeFields> deviceslist2;
        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblSALIDA.Font = new Font(ff, 26, fontStyle);
  
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

        
        public List<Movimientos> movimientos;
        public SALIDA()
        {
            InitializeComponent();
            pictureBox1.BringToFront();
            movimientos = new List<Movimientos>();
            listaLugares = new List<Tuple<Int32, String>>();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void CheckEnter(object sender, KeyEventArgs e)
        {        
            if (e.KeyCode == Keys.Enter)
            {
                if (codigos.Count != 0)
                {
                    if (codigos.Contains(this.txtBUSCADOR.Text))
                    {
                        MessageBox.Show("el producto ya esta en la lista deseada");
                        return;
                    }
                }
                busqueda();
            }          
        }

        public async void busqueda() {

            //busqueda
            if (txtBUSCADOR.Text == "") {
                MessageBox.Show("Campo de Texto vacio");
                return;          
            }
            if (txtBUSCADOR.Text.StartsWith("AV"))
            {
                if (!codigos.Contains(txtBUSCADOR.Text))
                {
                    codigos.Add(txtBUSCADOR.Text);
                    string[] row = new string[] { txtBUSCADOR.Text,"1" };
                    dgvSalida.Rows.Add(row);
                    
                    lbCount.Text = codigos.Count.ToString();
                    Thread myNewThread = new Thread(() => BusquedaAsync(txtBUSCADOR.Text));
                    myNewThread.Start();

                }
                else
                {
                    MessageBox.Show("Codigo Añadido");
                    txtBUSCADOR.Text = "";
                    return;
                }
            }
        }


        public async Task<bool> BusquedaAsync(String code)
        {
            QueryDevice devicequery = new QueryDevice();
            devicequery.codigo = code;
            this.txtBUSCADOR.Invoke((MethodInvoker)delegate
            {
                this.txtBUSCADOR.Text = "";
            });
            string json = JsonConvert.SerializeObject(devicequery,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            var url = HttpMethods.url + "dispositivos/query";
            StatusMessage statusmessage = await HttpMethods.Post(url, json);
            Console.WriteLine(statusmessage.statuscode.ToString(), url);
            if (statusmessage.statuscode == 500)
            {
                this.Invoke(new Action(() => { MessageBox.Show(this, "Ocurrio un error al agregar el producto " + code); }));
                delete_code_tables(code);
                return false;
            }

            if (statusmessage.statuscode == 409)
            {
                this.Invoke(new Action(() => { MessageBox.Show(this, "No existe el producto " + code); }));
                
                delete_code_tables(code);
                return false;
            }
            if (statusmessage.statuscode == 200)
            {
                devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                if (devices.Count == 0)
                {
                    this.Invoke(new Action(() => { MessageBox.Show(this, "No existe el producto " + code); }));
                    delete_code_tables(code);
                    return false;
                }
                int cantidad_a_salir = 1;
                if (!check_cantidad(devices[0].codigo, devices[0].cantidad, ref cantidad_a_salir))
                {
                    this.Invoke(new Action(() => { MessageBox.Show(this, "La cantidad indicada no existe en el inventario para el producto " + code); }));
                    delete_code_tables(code);
                    return false;
                }
                Agregar(devices[0], cantidad_a_salir);
            }
            return true;
            
        }

        private bool Agregar(Devices device,int cantidad_a_salir) {
            //convert device to movement
            Movimientos movement = new Movimientos();
            movement.usuarioId = CurrentUsers.id;
            movement.dispositivoId = device.id;
            movement.dispositivo = device;                        
            movement.tipoMovId = 1;
            movement.cantidad_Actual = cantidad_a_salir;
            bool deviceExist = movimientos.Any(x => x.dispositivoId == device.id && x.dispositivoId == device.id);
            movement.dispositivo_Actual = device.producto;
            movement.codigo_Actual = device.codigo;
            movement.tipo_Actual = "salida";
            movement.LugarId = VG.id_current_lugar;
            movimientos.Add(movement);
            return true;
            //string[] row = new string[] { device.codigo, device.producto,device.modelo };
            //dgvSalida.Rows.Add(row);
        }
        

        private async void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (codigos.Count == 0) {
                MessageBox.Show("No hay productos para realizar una salida");
                return;
            }
            pictureBox1.Visible = true;
            while(true)
            {
                Console.WriteLine(movimientos.Count.ToString() + "," + codigos.Count.ToString());
                if (movimientos.Count == codigos.Count)
                {
                    pictureBox1.Visible = false;
                    break;
                }
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

        private void SALIDA_LoadAsync(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            dgvSalida.Columns.Add("Codigo", "Codigo");
            dgvSalida.Columns.Add("Cantidad", "Cantidad");


            btnclm = new DataGridViewButtonColumn();
            btnclm.Name = "El";
            btnclm.Text = "Eliminar";
            btnclm.HeaderText = "Eliminar";
            btnclm.UseColumnTextForButtonValue = true;
            btnclm.DefaultCellStyle.BackColor = Color.Red;
            btnclm.DefaultCellStyle.ForeColor = Color.White;
            this.dgvSalida.Columns.Add(btnclm);

            lblSALIDA.Text = "SALIDA " + "(" + lugar.lugar + ")";

        }

        private void dgvCarritoSalida_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvSalida.Columns.IndexOf(btnclm))
            {
                try
                {
                    //DataGridViewRow row = dgvCarritoSalida.Rows[e.RowIndex];
                    dgvSalida.Rows.RemoveAt(dgvSalida.CurrentRow.Index);
                    this.movimientos.RemoveAt(e.RowIndex);
                    //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
                    this.codigos.RemoveAt(e.RowIndex);
                    lbCount.Text = codigos.Count.ToString();
                }
                catch (Exception ex)
                {

                }


            }
        }

        
         public SALIDA(Lugares l)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Productos","Productos");
            this.lugar = l;
            
            movimientos = new List<Movimientos>();
            listaLugares = new List<Tuple<Int32, String>>();
            dataGridView1.BringToFront();
        }
        private void dgvSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!codigos.Contains(deviceslist2[e.RowIndex].codigo))
                {
                if (textBox1.Text == "CANTIDAD = 1")
                {
                    string[] row = new string[] { deviceslist2[e.RowIndex].codigo, "1" };
                    dgvSalida.Rows.Add(row);
                    codigos.Add(deviceslist2[e.RowIndex].codigo);
                    lbCount.Text = codigos.Count.ToString();
                    Thread myNewThread = new Thread(() => BusquedaAsync(deviceslist2[e.RowIndex].codigo));
                    myNewThread.Start();

                }
                else
                {
                    int x = 0;

                    if (Int32.TryParse(textBox1.Text, out x))
                    {
                        string[] row = new string[] { deviceslist2[e.RowIndex].codigo, x.ToString() };
                        dgvSalida.Rows.Add(row);
                        codigos.Add(deviceslist2[e.RowIndex].codigo);
                        lbCount.Text = codigos.Count.ToString();
                        Thread myNewThread = new Thread(() => BusquedaAsync(deviceslist2[e.RowIndex].codigo));
                        myNewThread.Start();
                    }
                    else
                    {
                        MessageBox.Show("Introduzca un numero valido ");
                    }
                }
                textBox1.Text = "CANTIDAD = 1";
                txtBUSCADOR.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Visible = false;
            }
            else
            {
                MessageBox.Show("el producto ya esta en la lista deseada");
                return;
            }

        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {
            if ( txtBUSCADOR.Text != "")
            {
                if(txtBUSCADOR.Text.Length == 1)
                {
                    if (txtBUSCADOR.Text[0] != 'A')
                    {

                        busquedaNormal();
                    }
                }
                else if (txtBUSCADOR.Text.Length > 1)
                {
                    if (txtBUSCADOR.Text[0] != 'A' && txtBUSCADOR.Text[1] != 'V')
                    {
                        busquedaNormal();
                    }
                    else if (txtBUSCADOR.Text[0] == 'A' && txtBUSCADOR.Text[1] != 'V')
                    {
                        busquedaNormal();
                    }
                }

            }
            else
            {
                dataGridView1.Visible = false;
            }
        }

        private async void busquedaNormal()
        {
            try
            {
     
                dataGridView1.Rows.Clear();
                dataGridView1.Visible = true;
                dataGridView1.Height = 15;
                var url = HttpMethods.url + "dispositivos/filterdeviceFields?limit=20&offset=1&inStorage=1";
                StatusMessage statusmessage2 = await HttpMethods.get(url, txtBUSCADOR.Text);
                if (statusmessage2.statuscode != 200)
                {
                    return;
                }

                deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);
                dataGridView1.Rows.Clear();
                for (int x = 0; x < deviceslist2.Count; x++)
                {
                    if (dataGridView1.Height < 300)
                    { 
                    dataGridView1.Height = dataGridView1.Height + 15;
                    }
                    DeviceSomeFields inv = deviceslist2[x];
                    deviceslist2[x].producto = inv.producto;
                    deviceslist2[x].codigo = inv.codigo;
                    deviceslist2[x].lugar = inv.lugar;
                    deviceslist2[x].marca = inv.marca;
                    deviceslist2[x].modelo = inv.modelo;
                    deviceslist2[x].descripcion = inv.descripcion;
                    deviceslist2[x].serie = inv.serie;

                    string[] row = new string[] { deviceslist2[x].producto};

                    dataGridView1.Rows.Add(row);
                    dataGridView1.Columns[0].Width = 250;


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }


        private void delete_code_tables(string code)
        {
            int indiceFila = 0;
            foreach (DataGridViewRow fila in dgvSalida.Rows)
            {
                
                string valorCelda = fila.Cells["codigo"].Value?.ToString();

                if (!string.IsNullOrEmpty(valorCelda) && valorCelda.Equals(code))
                {
                    indiceFila = fila.Index;
                    break; 
                }
            }
            this.dgvSalida.Invoke((MethodInvoker)delegate
            {
                this.dgvSalida.Rows.RemoveAt(indiceFila);
            });
            
            //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
            this.codigos.Remove(code);
            this.lbCount.Invoke((MethodInvoker)delegate
            {
                this.lbCount.Text = codigos.Count.ToString();
            });
            
        }

        private bool check_cantidad(string code,int cant,ref int cantidad_a_salir)
        {
            cantidad_a_salir = 1;
            foreach (DataGridViewRow fila in dgvSalida.Rows)
            {

                string valorCelda = fila.Cells["codigo"].Value?.ToString();

                if (!string.IsNullOrEmpty(valorCelda) && valorCelda.Equals(code))
                {
                   
                    DataGridViewCellCollection columna = fila.Cells;
                    DataGridViewCell segundaCelda = fila.Cells[1];  // Obtiene la segunda celda (índice 1).

                    if (segundaCelda.Value != null)
                    {
                        Int16 valorSegundaCelda =Int16.Parse(segundaCelda.Value.ToString());
                        if ((Int16)cant >= valorSegundaCelda)
                        {
                            cantidad_a_salir = (int)valorSegundaCelda;
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
 
            return false;
        }
        private async Task<bool> validate_devices_movements()
        {
            //check if devices exist
            if (codigos.Count == 0)
            {
                MessageBox.Show("No hay productos para realizar una salida");
                return false;

            }

            foreach(string codigo in codigos)
            {
                //search device
                var url = HttpMethods.url + "dispositivos/filterdeviceByCodigo";
                StatusMessage statusmessage = await HttpMethods.get(url, codigo);


                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("el producto con el codigo" + codigo + " no existe, favor de verificarlo de nuevo");
                    delete_code_tables(codigo);
                    return false;
                }


                if (statusmessage.statuscode != 200)
                {
                    MessageBox.Show("Ocurrio un error durante la peticion, probablemente no exista el producto con codigo "+codigo);
                    delete_code_tables(codigo);
                    return false;
                }



                Devices deviceslistcheck = JsonConvert.DeserializeObject<Devices>(statusmessage.data);

                if(deviceslistcheck==null)
                {
                    delete_code_tables(codigo);
                    MessageBox.Show("el producto con el codigo"+codigo+" no existe, favor de verificarlo de nuevo");
                    return false;
                }
                int cantidad_a_salir = 1;
                if (!check_cantidad(codigo, deviceslistcheck.cantidad, ref cantidad_a_salir))
                {
                    MessageBox.Show("el producto con el codigo " + codigo + " no cuenta con las cantidades que deseas sacar del almacen");
                    delete_code_tables(codigo);
                    return false;
                }
                Agregar(deviceslistcheck, cantidad_a_salir);
                
            }

            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
