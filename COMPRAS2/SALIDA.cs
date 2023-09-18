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
                busqueda();
            }          
        }

        public void busqueda() {

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
                    string[] row = new string[] { txtBUSCADOR.Text };
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

        private bool Agregar(Devices device) {
            //convert device to movement
            Movimientos movement = new Movimientos();
            movement.usuarioId = CurrentUsers.id;
            movement.dispositivoId = device.id;
            movement.dispositivo = device;                        
            movement.tipoMovId = 1;
            bool deviceExist = movimientos.Any(x => x.dispositivoId == device.id && x.dispositivoId == device.id);
            ///if (deviceExist) {
                //MessageBox.Show("el producto ya existe en la lista");
               // return false;
            //}
            txtBUSCADOR.Text = "";
            count++;
            lbCount.Text = count.ToString();
            lbCount.Text = count.ToString();
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
            await validate_devices_movements();
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

        private async void SALIDA_LoadAsync(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            dgvSalida.Columns.Add("Codigo", "Codigo");
            

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

                    //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
                    this.codigos.RemoveAt(e.RowIndex);
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
        }
        private void dgvSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string[] row = new string[] { deviceslist2[e.RowIndex].producto };
            dgvSalida.Rows.Add(row);
            codigos.Add(deviceslist2[e.RowIndex].codigo);
            txtBUSCADOR.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Visible = false;
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
                var url = HttpMethods.url + "dispositivos/filterdeviceFields?limit=30&offset=1";
                StatusMessage statusmessage2 = await HttpMethods.get(url, txtBUSCADOR.Text);

                if (statusmessage2.statuscode != 200)
                {
                    return;
                }

                deviceslist2 = JsonConvert.DeserializeObject<List<DeviceSomeFields>>(statusmessage2.data);

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
            dgvSalida.Rows.RemoveAt(indiceFila);
            
            //movimientos.RemoveAt(dgvCarritoSalida.CurrentRow.Index);
            this.codigos.Remove(code);
        }
        private async         Task
validate_devices_movements()
        {
            //check if devices exist
            if (codigos.Count == 0)
            {
                MessageBox.Show("No hay productos para realizar una salida");
                return;

            }

            foreach(string codigo in codigos)
            {
                //search device
                var url = HttpMethods.url + "dispositivos/filterdeviceminFields?limit=2&offset=1";
                StatusMessage statusmessage = await HttpMethods.get(url, codigo);



                if (statusmessage.statuscode != 200)
                {
                    MessageBox.Show("Ocurrio un error durante la peticion");
                    return;
                }



                List<Devices> deviceslistcheck = JsonConvert.DeserializeObject<List<Devices>>(statusmessage.data);

                if(deviceslistcheck==null || deviceslistcheck.Count == 0)
                {
                    delete_code_tables(codigo);
                    MessageBox.Show("el producto con e codigo"+codigo+" no existe, favor de verificarlo de nuevo");
                    return;
                }
                Agregar(deviceslistcheck[0]);
                
            }
        }
    }
}
