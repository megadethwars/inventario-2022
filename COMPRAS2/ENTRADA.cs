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
        int count = 0;
        DataGridViewButtonColumn btnclm;
        List<Tuple<Int32, String>> listaLugares;
        Lugares lugar = new Lugares();
        List<String> codigos = new List<String>();
        public List<DeviceSomeFields> deviceslist2;
        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblCarritoDeSalida.Font = new Font(ff, 26, fontStyle);
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
            if (txtBUSCADOR.Text == "")
            {
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
                    txtBUSCADOR.Text = "";
                }
                else
                {
                    MessageBox.Show("Codigo Añadido");
                    txtBUSCADOR.Text = "";
                    return;
                }
            }
        }

        private void Agregar(Devices device,int cantidad_a_entrar)
        {
            //convert device to movement
            Movimientos movement = new Movimientos();
            movement.usuarioId = CurrentUsers.id;
            movement.dispositivoId = device.id;
            movement.dispositivo = device;
            movement.tipoMovId = 2;
            movement.cantidad_Actual = cantidad_a_entrar;
            bool deviceExist = movimientos.Any(x => x.dispositivoId == device.id && x.dispositivoId == device.id);
            if (deviceExist)
            {
                MessageBox.Show("el producto ya existe en la lista");
                return;
            }
            movimientos.Add(movement);
        }

        private async void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (codigos.Count == 0)
            {
                MessageBox.Show("No hay productos para realizar una salida");
                return;
            }
            pictureBox1.Visible = true;
            bool result = await validate_devices_movements();
            pictureBox1.Visible = false;

            if (!result)
            {
                return;
            }

            Navigator.nextPage(new CarritoEntrada(this));
        }

        private void ENTRADA_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            dgvSalida.Columns.Add("Codigo", "Codigo");
            dgvSalida.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Productos", "Productos");
            btnclm = new DataGridViewButtonColumn();
            btnclm.Name = "El";
            btnclm.Text = "Eliminar";
            btnclm.HeaderText = "Eliminar";
            btnclm.UseColumnTextForButtonValue = true;
            btnclm.DefaultCellStyle.BackColor = Color.Red;
            btnclm.DefaultCellStyle.ForeColor = Color.White;
            this.dgvSalida.Columns.Add(btnclm);

        }

        private void btClear_Click(object sender, EventArgs e)
        {
            isFirst = false;
            movimientos.Clear();

        }

        private void txtBUSCADOR_TextChanged(object sender, EventArgs e)
        {
            if (txtBUSCADOR.Text != "")
            {
                if (txtBUSCADOR.Text.Length == 1)
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
                var url = HttpMethods.url + "dispositivos/filterdeviceminFields?limit=20&offset=1&inStorage=2";
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

                    string[] row = new string[] { deviceslist2[x].codigo };

                    dataGridView1.Rows.Add(row);
                    dataGridView1.Columns[0].Width = 250;


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo ");
            }
        }

        private void txtBUSCADOR_Click(object sender, EventArgs e)
        {
            txtBUSCADOR.Clear();
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            busqueda();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textBox1.Text == "CANTIDAD = 1")
            {
                string[] row = new string[] { deviceslist2[e.RowIndex].codigo, "1" };
                dgvSalida.Rows.Add(row);
                codigos.Add(deviceslist2[e.RowIndex].codigo);

            }
            else
            {
                int x = 0;

                if (Int32.TryParse(textBox1.Text, out x))
                {
                    string[] row = new string[] { deviceslist2[e.RowIndex].codigo, x.ToString() };
                    dgvSalida.Rows.Add(row);
                    codigos.Add(deviceslist2[e.RowIndex].codigo);
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
            dgvSalida.Rows.RemoveAt(indiceFila);

            //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
            this.codigos.Remove(code);
        }

        private bool check_cantidad(string code, int cant, ref int cantidad_a_salir)
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
                        Int16 valorSegundaCelda = Int16.Parse(segundaCelda.Value.ToString());
                        cantidad_a_salir = (int)valorSegundaCelda;
                        return true;
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

            foreach (string codigo in codigos)
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
                    MessageBox.Show("Ocurrio un error durante la peticion, probablemente no exista el producto con codigo " + codigo);
                    delete_code_tables(codigo);
                    return false;
                }



                Devices deviceslistcheck = JsonConvert.DeserializeObject<Devices>(statusmessage.data);

                if (deviceslistcheck == null)
                {
                    delete_code_tables(codigo);
                    MessageBox.Show("el producto con el codigo" + codigo + " no existe, favor de verificarlo de nuevo");
                    return false;
                }
                int cantidad_a_entrar = 1;
                if (!check_cantidad(codigo, deviceslistcheck.cantidad, ref cantidad_a_entrar))
                {
                    MessageBox.Show("el producto con el codigo" + codigo + " no cuenta con las cantidades que deseas meter al almacen");
                    delete_code_tables(codigo);
                    return false;
                }
                Agregar(deviceslistcheck, cantidad_a_entrar);

            }

            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void dgvSalida_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvSalida.Columns.IndexOf(btnclm))
            {
                try
                {
                    //DataGridViewRow row = dgvCarritoSalida.Rows[e.RowIndex];
                    dgvSalida.Rows.RemoveAt(dgvSalida.CurrentRow.Index);

                    //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
                    this.codigos.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {

                }


            }
        }
    }
}
