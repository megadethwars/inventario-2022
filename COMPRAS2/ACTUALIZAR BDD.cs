using COMPRAS2.modelos;
using COMPRAS2.servicios;
using Newtonsoft.Json;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPRAS2
{
    public partial class ACTUALIZAR_BDD : Form
    {
        string path;
        bool isStopped = false;
        public ACTUALIZAR_BDD()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            if(OFDActualizar.ShowDialog() == DialogResult.OK)
            {
                lblNombreArchivo.Text = OFDActualizar.FileName;
                path = OFDActualizar.FileName;
            }
        }

        private void btnINICIAR_Click(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex) { 
            }
        }


        private async void syncDataBase() {
            try
            {
                isStopped = false;

                if (path == "") {
                    MessageBox.Show("No se ha seleccionado ningun archivo");
                    return;
                }

                FileStream fStream = File.Open(path, FileMode.Open, FileAccess.Read);



                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;


                IWorkbook workbook = application.Workbooks.Open(fStream);

                //Access first worksheet from the workbook.
                IWorksheet worksheet = workbook.Worksheets[1];

                int row = 2;

                while (!worksheet.GetValueRowCol(row, 2).Equals("") && worksheet.GetValueRowCol(row, 2) != null)
                {

                    if (isStopped)
                    {
                        porcentaje.Text = "Detenido";
                        break;
                    }

                    //columnas

                    var strs = worksheet.GetText(row, 1);

                    //list = await App.MobileService.GetTable<InventDB>().Where(u => u.codigo == strs).ToListAsync();


                    var url = HttpMethods.url + "dispositivos";
                    StatusMessage statusmessage = await HttpMethods.get(url);



                    if (statusmessage == null)
                    {

                        MessageBox.Show("error de conexion con el servidor");
                        porcentaje.Text = "Error de conexion";
                        break;
                    }

                    if (statusmessage.statuscode == 500)
                    {
                        MessageBox.Show("error de conexion con el servidor");
                        porcentaje.Text = "Error de sincronizacion";
                        break;
                    }

                    if (statusmessage.statuscode == 404)
                    {
                        //await DisplayAlert("Buscando", "producto no encontrado", "OK");

                        //var id = Guid.NewGuid().ToString();
                        Devices n = new Devices
                        {

                            codigo = strs,
                            serie = (string)worksheet.GetValueRowCol(row, 2),
                            compra = worksheet.GetText(row, 8),
                            costo = int.Parse(worksheet.GetText(row, 6)),
                            descompostura = worksheet.GetText(row, 11),
                            marca = worksheet.GetText(row, 4),
                            modelo = worksheet.GetText(row, 5),
                            producto = worksheet.GetText(row, 3),
                            observaciones = worksheet.GetText(row, 9),
                            origen = worksheet.GetText(row, 7),
                            pertenece = worksheet.GetText(row, 10),
                            //ID = id,
                            lugarId = 1,

                        };

                        n.serie = n.serie.Replace('\x22', '\0');

                        string json = JsonConvert.SerializeObject(n,
                        new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                        var urlpost = HttpMethods.url + "dispositivos";
                        StatusMessage statusmessagePost = await HttpMethods.Post(urlpost, json);


                        //await App.MobileService.GetTable<InventDB>().InsertAsync(n);
                        if (statusmessagePost.statuscode != 201) {
                            MessageBox.Show("Ocurrio un error durante la migracion en el producto " + n.codigo);
                            return;
                        }

                    }

                    if (statusmessage.statuscode == 200 || statusmessage.statuscode == 201)
                    {
                        Devices deviceUpdate = JsonConvert.DeserializeObject<Devices>(statusmessage.data);
                 

                        deviceUpdate.compra = worksheet.GetText(row, 8);
                        deviceUpdate.costo = int.Parse( worksheet.GetText(row, 6));
                        deviceUpdate.descompostura = worksheet.GetText(row, 11);
                        deviceUpdate.marca = worksheet.GetText(row, 4);
                        deviceUpdate.modelo = worksheet.GetText(row, 5);
                        deviceUpdate.producto = worksheet.GetText(row, 3);
                        deviceUpdate.observaciones = worksheet.GetText(row, 9);
                        deviceUpdate.origen = worksheet.GetText(row, 7);
                        deviceUpdate.pertenece = worksheet.GetText(row, 10);
                        deviceUpdate.serie = (string)worksheet.GetValueRowCol(row, 1);
                        deviceUpdate.lugarId = 1;
                        deviceUpdate.serie = deviceUpdate.serie.Replace('\x22', '\0');

                        string json = JsonConvert.SerializeObject(deviceUpdate,
                        new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                        var urlput = HttpMethods.url + "dispositivos";
                        StatusMessage statusmessageput = await HttpMethods.put(urlput, json);

                        if (statusmessageput.statuscode != 200)
                        {
                            MessageBox.Show("Ocurrio un error durante la migracion en el la actualizacion " + deviceUpdate.codigo);
                            return;
                        }
                    }



                    porcentaje.Text = worksheet.GetText(row, 1) + "  " + (row * 100 / 1576).ToString() + "%";
                    row = row + 1;
                }
                row = 2;
                porcentaje.Text = "terminado";

                workbook.Close();

            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrio un error en el proceso, revise el archivo que sea correcto, o su conexion a internet");
            }
        
        }

        private void btnDETENER_Click(object sender, EventArgs e)
        {
            isStopped = true;
        }
    }
}
