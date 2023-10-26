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
    public partial class REPORTES : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblREPORTES.Font = new Font(ff, 26, fontStyle);
            this.lblNombreProducto.Font = new Font(ff, 20, fontStyle);
            this.label3.Font = new Font(ff, 20, fontStyle);
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

        public REPORTES()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async Task<int> Auth()
        {
            try
            {
                int cantidad = 0;
                Int32 costo = 0;
                if (txtNombreDelProducto.Text == "")
                {
                    MessageBox.Show("campo de producto vacio");
                    return 1;
                }

                if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("campo de descripcion vacio");
                    return 1;
                }

                QueryReporte query = new QueryReporte();
                query.codigo = txtNombreDelProducto.Text;

                string jsonquery = JsonConvert.SerializeObject(query,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var urlquery = HttpMethods.url + "dispositivos/query";
                pictureBox2.Visible = true;
                StatusMessage statusmessagequery = await HttpMethods.Post(urlquery, jsonquery);

                Reportes reporte = new Reportes();
                List<Devices> devices;
                if (statusmessagequery.statuscode == 200)
                {
                    //var auth = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                    devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessagequery.data);
                    if (devices.Count== 0)
                    {
                        pictureBox2.Visible = false;
                        MessageBox.Show("El producto no fue encontrado");
                        
                        return 1;
                    }

                    reporte.dispositivoId = devices[0].id;                 

                }
                else {
                    pictureBox2.Visible = false;
                    MessageBox.Show("error en el servicio, Producto no existente");
                    return 2;
                }
                            
                reporte.usuarioId = CurrentUsers.id;
                reporte.comentarios = txtDescripcion.Text;

                string json = JsonConvert.SerializeObject(reporte,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "reportes";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);

                pictureBox2.Visible = false;
                if (statusmessage.statuscode == 409)
                {
                    MessageBox.Show("error en el servicio, posiblemente el producto ya exista");
                    return 2;
                }

                else if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("error en el servicio");
                    return 2;
                }
                else if (statusmessage.statuscode == 201)
                {
                    //var auth = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                    List<Reportes> reportes = JsonConvert.DeserializeObject<List<Reportes>>(statusmessage.data);
                    MessageBox.Show("REPORTE AGREGADO CORRECTAMENTE");
                    Navigator.backPage(this.Name, this);
                    return 0;
                }
                else if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("error en el servicio, NO encontrado");

                    return 2;
                }
                else
                {
                    MessageBox.Show("error en el servicio, Ocurrio algun conflicto");
                    return 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo");
                return 10;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnOPCIONES_Click(object sender, EventArgs e)
        {
            //Navigator.nextPage(new REPORTES2());
        }

        private async void btnOK_ClickAsync(object sender, EventArgs e)
        {
            int result = await Auth();
        }
        
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Escriba Aqui";
                //txtDescripcion.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }

        private void txtNombreDelProducto_Click(object sender, EventArgs e)
        {
            txtNombreDelProducto.Clear();
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
        }

        private void txtNombreDelProducto_Leave(object sender, EventArgs e)
        {
            if (txtNombreDelProducto.Text == "")
            {
                txtNombreDelProducto.Text = "Producto";
                //txtDescripcion.ForeColor = Color.FromArgb(148, 148, 202);
            }
        }

        private void REPORTES_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
