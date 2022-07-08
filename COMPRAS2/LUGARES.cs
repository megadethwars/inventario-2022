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
    public partial class LUGARES : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;

            this.lblLugares.Font = new Font(ff, 26, fontStyle);
            this.lblIngresarLugarDeseado.Font = new Font(ff, 20, fontStyle);
            this.btnActualizar.Font = new Font(ff, 18, fontStyle);
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

        string url = "https://avsinventoryswagger.azurewebsites.net/api/v1/";

        public LUGARES()
        {
            InitializeComponent();
        }

        private void bTNBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private async void LUGARES_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);

            var url = HttpMethods.url + "lugares";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }
            
            List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);

            dgvLugares.DataSource = devices;
            this.dgvLugares.Columns["fechaAlta"].Visible = false;
            this.dgvLugares.Columns["fechaUltimaModificacion"].Visible = false;
            this.dgvLugares.Columns["id"].Visible = false;
            this.dgvLugares.Columns["activo"].Visible = false;
        }

        private async Task<int> Auth()
        {
            try
            {
                Lugares lugarnew = new Lugares();
                lugarnew.lugar = txtLugarDeseado.Text;

                string json = JsonConvert.SerializeObject(lugarnew,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "lugares";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);


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
                    List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);
                    MessageBox.Show("PRODUCTO AGREGADO CORRECTAMENTE");                    

                    return 0;
                }
                else if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("error en el servicio, NO encontrado");

                    return 2;
                }
                else
                {
                    return 2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error en la respuesta, reintente de nuevo");
                return 10;
            }
        }

        private void txtLugarDeseado_Click(object sender, EventArgs e)
        {
            txtLugarDeseado.Clear();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            int status = await Auth();           
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvLugares.DataSource = null;
            var url = HttpMethods.url + "lugares";
            StatusMessage statusmessage = await HttpMethods.get(url);

            if (statusmessage.statuscode != 200)
            {
                return;
            }

            List<Lugares> devices = JsonConvert.DeserializeObject<List<Lugares>>(statusmessage.data);

            dgvLugares.DataSource = devices;
            this.dgvLugares.Columns["fechaAlta"].Visible = false;
            this.dgvLugares.Columns["fechaUltimaModificacion"].Visible = false;
            this.dgvLugares.Columns["id"].Visible = false;
            this.dgvLugares.Columns["activo"].Visible = false;
        }

        public void dgvLugares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow cell = dgvLugares.Rows[e.RowIndex];
                Lugares lug = (Lugares)cell.DataBoundItem;

                Navigator.nextPage(new EDITAR_LUGARES(lug));

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
