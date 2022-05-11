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
using System.Threading;
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
                Thread th = new Thread(syncDataBase);

                th.Start();

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
                IWorksheet worksheet = workbook.Worksheets[0];

                int row = 2;
         

                while (!worksheet.GetValueRowCol(row, 2).Equals("") || !worksheet.GetValueRowCol(row+1, 2).Equals("") || !worksheet.GetValueRowCol(row+2, 2).Equals("") || !worksheet.GetValueRowCol(row + 3, 2).Equals("") || !worksheet.GetValueRowCol(row + 4, 2).Equals("") || !worksheet.GetValueRowCol(row + 5, 2).Equals("") || !worksheet.GetValueRowCol(row + 6, 2).Equals(""))
                {

                    if (isStopped)
                    {
                        this.Invoke((MethodInvoker)delegate(){
                            porcentaje.Text = "Detenido";
                        });
                        workbook.Close();
                        fStream.Close();

                        break;
                    }

                    //columnas

                    var strs = worksheet.GetText(row, 1);
                    if (strs == "") {
                        row = row + 1;
                        continue;
                    }
                    //list = await App.MobileService.GetTable<InventDB>().Where(u => u.codigo == strs).ToListAsync();


                  
                    QueryDevice devicequery = new QueryDevice();
                    devicequery.codigo = strs;
                    string jsonD = JsonConvert.SerializeObject(devicequery,
                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                    var urlD = HttpMethods.url + "dispositivos/query";
                    StatusMessage statusmessageD = await HttpMethods.Post(urlD, jsonD);

                    if (statusmessageD == null)
                    {

                        MessageBox.Show("error de conexion con el servidor");
                        this.Invoke((MethodInvoker)delegate () {
                            porcentaje.Text = "Error de conexion";
                        });
                        workbook.Close();
                        fStream.Close();
                        break;
                    }

                    if (statusmessageD.statuscode == 500)
                    {
                        MessageBox.Show("error de conexion con el servidor");
                        
                        this.Invoke((MethodInvoker)delegate () {
                            porcentaje.Text = "Error de sincronizacion";
                        });
                        workbook.Close();
                        fStream.Close();
                        break;
                    }

                    if (statusmessageD.statuscode == 200)
                    {
                        //await DisplayAlert("Buscando", "producto no encontrado", "OK");

                        //var id = Guid.NewGuid().ToString();
                        List<Devices> devices = JsonConvert.DeserializeObject<List<Devices>>(statusmessageD.data);
                 
                        if (devices.Count == 0)
                        {

                            DeviceMigrate n = new DeviceMigrate();
                            n.codigo = strs;
                            n.serie = (string)worksheet.GetValueRowCol(row, 2);
                            n.compra = worksheet.GetText(row, 8);
                            try
                            {
                                n.costo = int.Parse((string)worksheet.GetValueRowCol(row, 6));
                                if (n.costo == 0) {
                                    n.costo = 1;
                                }
                            }
                            catch {
                                n.costo = 1;

                            }
                            
                            n.descompostura = (string)worksheet.GetValueRowCol(row, 11);
                            n.marca = (string)worksheet.GetValueRowCol(row, 4);
                            n.modelo = (string)worksheet.GetValueRowCol(row, 5);
                            n.producto = (string)worksheet.GetValueRowCol(row, 3);
                            n.observaciones = (string)worksheet.GetValueRowCol(row, 9);
                            n.origen = (string)worksheet.GetValueRowCol(row, 7);
                            n.pertenece = (string)worksheet.GetValueRowCol(row, 10);
                            //ID = id,
                            n.lugarId = 1;
                            n.cantidad = 2;
                            n.statusId = 1;
                            n.serie = n.serie.Replace('\x22', '\0');
                            

                            string json = JsonConvert.SerializeObject(n,
                            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                            var urlpost = HttpMethods.url + "dispositivos";
                            StatusMessage statusmessagePost = await HttpMethods.Post(urlpost, json);


                            //await App.MobileService.GetTable<InventDB>().InsertAsync(n);
                            if (statusmessagePost.statuscode != 201)
                            {
                                MessageBox.Show("Ocurrio un error durante la migracion en el producto " + n.codigo);
                                workbook.Close();
                                fStream.Close();
                                return;
                            }
                        }
                        else {
                            List<DeviceMigrate> deviceUpdate = JsonConvert.DeserializeObject<List<DeviceMigrate>>(statusmessageD.data);

                            DeviceMigrate devUpd = new DeviceMigrate();
                            devUpd.id = deviceUpdate[0].id;

                            devUpd.compra = (string)worksheet.GetValueRowCol(row, 8);
                            try
                            {
                                devUpd.costo = int.Parse((string)worksheet.GetValueRowCol(row, 6));
                                if (devUpd.costo == 0)
                                {
                                    devUpd.costo = 1;
                                }
                            }
                            catch
                            {
                                devUpd.costo = 1;
                            }

                            devUpd.descompostura = (string)worksheet.GetValueRowCol(row, 11);
                            devUpd.marca = (string)worksheet.GetValueRowCol(row, 4);
                            devUpd.modelo = (string)worksheet.GetValueRowCol(row, 5);
                            devUpd.producto = (string)worksheet.GetValueRowCol(row, 3);
                            devUpd.observaciones = (string)worksheet.GetValueRowCol(row, 9);
                            devUpd.origen = (string)worksheet.GetValueRowCol(row, 7);
                            devUpd.pertenece = (string)worksheet.GetValueRowCol(row, 10);
                            devUpd.serie = (string)worksheet.GetValueRowCol(row, 1);
                            devUpd.lugarId = 1;
                            devUpd.serie = (string)devUpd.serie.Replace('\x22', '\0');

                            string json = JsonConvert.SerializeObject(devUpd,
                            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                            var urlput = HttpMethods.url + "dispositivos";
                            StatusMessage statusmessageput = await HttpMethods.put(urlput, json);

                            if (statusmessageput.statuscode != 200)
                            {
                                MessageBox.Show("Ocurrio un error durante la migracion en el la actualizacion " + deviceUpdate[0].codigo);
                                workbook.Close();
                                fStream.Close();
                                return;
                            }
                        }

                        

                    }

                  


                    this.Invoke((MethodInvoker)delegate () {
                        porcentaje.Text = worksheet.GetText(row, 1) + "  " + (row * 100 / 1576).ToString() + "%";
                    });
                    
                    row = row + 1;
                }
                row = 2;
                
                this.Invoke((MethodInvoker)delegate () {
                    porcentaje.Text = "terminado";
                });
                workbook.Close();
                fStream.Close();
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
