using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using COMPRAS2.modelos;
using Newtonsoft.Json;
using COMPRAS2.servicios;
using System.Diagnostics;

namespace COMPRAS2
{
    public partial class PDFMovement : Form
    {
        DataTable table;
        string IdSalida;
        string correo;
        MemoryStream streamPDF;
        public PDFMovement(string idSalida)
        {
            InitializeComponent();

            streamPDF = new MemoryStream();
            IdSalida = idSalida;

            table = new DataTable();

            
        }

        private async void PDFMovement_Load(object sender, EventArgs e)
        {
            await MainTask();
        }


        public async Task InitPDFAsync(string idSalida)
        {
            streamPDF = new MemoryStream();
            IdSalida = idSalida;

            table = new DataTable();

            await MainTask();

        }


        public bool CreatePDF(Movimientos movimientos, DataTable tablacarrito, User User, int tipomov)
        {
            try
            {
                PdfDocument document = new PdfDocument();
                //Adds page settings
                document.PageSettings.Orientation = PdfPageOrientation.Portrait;
                document.PageSettings.Margins.All = 50;
                //Adds a page to the document
                PdfPage page = document.Pages.Add();

                PdfGraphics graphics = page.Graphics;

                //Loads the image from disk
                //PdfImage image = PdfImage.FromFile("Logo.png");
                Bitmap im = Properties.Resources.NewLogo;
                Stream imageStream = null;

                MemoryStream memStream = new MemoryStream();
                im.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                

                //Load the image from the disk.
                PdfBitmap image = new PdfBitmap(memStream);
                //Draw the image
                RectangleF bounds = new RectangleF(0, 0, 110, 110);
                //Draws the image to the PDF page
                page.Graphics.DrawImage(image, bounds);


                //DRAW THE MAIN TITLE
                PdfFont Headfont = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                //Creates a text element to add the invoice number
                PdfTextElement headelement = new PdfTextElement("AUDIO VIDEO SOLUTIONS ", Headfont);
                headelement.Brush = PdfBrushes.Red;
                PdfLayoutResult result = headelement.Draw(page, new PointF(graphics.ClientSize.Width - 350, graphics.ClientSize.Height - 740));


                PdfFont Subtitle = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                //Creates a text element to add the invoice number
                string hd = "ORDEN DE MOVIMIENTO";
                if (tipomov == 1)
                {
                    hd = "ORDEN DE ENTRADA ";
                }
                if (tipomov == 2)
                {
                    hd = "ORDEN DE SALIDA ";
                }

                PdfTextElement subtitelement = new PdfTextElement(hd, Subtitle);
                subtitelement.Brush = PdfBrushes.Red;
                PdfLayoutResult Subresult = subtitelement.Draw(page, new PointF(graphics.ClientSize.Width - 300, graphics.ClientSize.Height - 710));


                PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(222, 237, 242));
                bounds = new RectangleF(bounds.Right, Subresult.Bounds.Bottom, graphics.ClientSize.Width - 300, 50);
                //Draws a rectangle to place the heading in that region.
                graphics.DrawRectangle(solidBrush, bounds);

                //creating fields, folio, fecha, lugar
                PdfFont campofont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement lblugar = new PdfTextElement("EVENTO: ", campofont);
                lblugar.Brush = PdfBrushes.Black;
                PdfLayoutResult reslblugar = lblugar.Draw(page, new PointF(bounds.Left + 40, bounds.Top));

                PdfTextElement lbfecha = new PdfTextElement("FECHA: ", campofont);
                lbfecha.Brush = PdfBrushes.Black;
                PdfLayoutResult reslbfecha = lbfecha.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 16));

                PdfTextElement lbfolio = new PdfTextElement("FOLIO: ", campofont);
                lbfolio.Brush = PdfBrushes.Black;
                PdfLayoutResult reslbfolio = lbfolio.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 32));


                PdfBrush solidBrush2 = new PdfSolidBrush(new PdfColor(190, 220, 228));
                bounds = new RectangleF(bounds.Right, Subresult.Bounds.Bottom, graphics.ClientSize.Width - 300, 50);
                //Draws a rectangle to place the heading in that region.
                graphics.DrawRectangle(solidBrush2, bounds);


                //variables de campos
                PdfTextElement lugar = new PdfTextElement(movimientos.dispositivo.lugar.lugar, campofont);
                lugar.Brush = PdfBrushes.Black;
                PdfLayoutResult reslugar = lugar.Draw(page, new PointF(bounds.Left + 40, bounds.Top));

                PdfTextElement fecha = new PdfTextElement(DateTime.Now.ToString(), campofont);
                fecha.Brush = PdfBrushes.Black;
                PdfLayoutResult resfecha = fecha.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 16));

                PdfTextElement folio = new PdfTextElement(movimientos.idMovimiento, campofont);
                folio.Brush = PdfBrushes.Black;
                PdfLayoutResult resfolio = folio.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 32));

                //create table

                //Creates the datasource for the table
                DataTable invoiceDetails = tablacarrito;
                //Creates a PDF grid
                PdfGrid grid = new PdfGrid();
                //Adds the data source
                grid.DataSource = invoiceDetails;
                //Creates the grid cell styles
                PdfGridCellStyle cellStyle = new PdfGridCellStyle();
                cellStyle.Borders.All = PdfPens.White;
                PdfGridRow header = grid.Headers[0];
                //Creates the header style
                PdfGridCellStyle headerStyle = new PdfGridCellStyle();
                headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
                headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
                headerStyle.TextBrush = PdfBrushes.White;
                headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16f, PdfFontStyle.Regular);

                //Adds cell customizations
                for (int i = 0; i < header.Cells.Count; i++)
                {
                    if (i == 0 || i == 1)
                        header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    else
                        header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                }

                //Applies the header style
                header.ApplyStyle(headerStyle);
                cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
                cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10f);
                cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
                //Creates the layout format for grid
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                // Creates layout format settings to allow the table pagination
                layoutFormat.Layout = PdfLayoutType.Paginate;

                //Draws the grid to the PDF page.
                PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 150), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);

                PdfGraphics graphicsSecond = gridResult.Page.Graphics;

                PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 1.0f);
                PointF startPoint = new PointF(0, gridResult.Bounds.Bottom + 60);
                PointF endPoint = new PointF(150, gridResult.Bounds.Bottom + 60);
                //Draws a line at the bottom of the address
                graphicsSecond.DrawLine(linePen, startPoint, endPoint);


                PdfFont entregafont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement lbentrega = new PdfTextElement("ENTREGA: ", entregafont);
                lbentrega.Brush = PdfBrushes.Black;
                PdfLayoutResult reslbentrega = lbentrega.Draw(gridResult.Page, new PointF(linePen.Width / 2.0f, startPoint.Y + 5));

                //texto de quien entrega
                PdfFont usuarioentregafont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement lbusuarioentrega = new PdfTextElement(CurrentUsers.nombre + " " + CurrentUsers.apellidoPaterno, usuarioentregafont);
                lbusuarioentrega.Brush = PdfBrushes.Black;
                PdfLayoutResult reslbusuarioentrega = lbusuarioentrega.Draw(gridResult.Page, new PointF(linePen.Width / 2.0f, startPoint.Y - 20));


                PdfPen linePenfinal = new PdfPen(new PdfColor(126, 151, 173), 1.0f);
                PointF startPointfinal = new PointF(350, gridResult.Bounds.Bottom + 60);
                PointF endPointfinal = new PointF(graphics.ClientSize.Width, gridResult.Bounds.Bottom + 60);
                //Draws a line at the bottom of the address
                graphicsSecond.DrawLine(linePenfinal, startPointfinal, endPointfinal);

                PdfFont recibefont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement lbrecibe = new PdfTextElement("RECIBE: ", recibefont);
                lbrecibe.Brush = PdfBrushes.Black;
                PdfLayoutResult reslbrecibe = lbrecibe.Draw(gridResult.Page, new PointF(350.0f + (linePenfinal.Width / 2.0f), startPoint.Y + 5));

                //texto de quien recibe
                PdfFont usuariofont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement lbusuario = new PdfTextElement(User.nombre + " " + User.apellidoPaterno, usuariofont);
                lbusuario.Brush = PdfBrushes.Black;
                PdfLayoutResult reslbusuario = lbusuario.Draw(gridResult.Page, new PointF(350.0f + (linePenfinal.Width / 2.0f), startPoint.Y - 20));


                MemoryStream stream = new MemoryStream();

                //Save the document.
                string save2 = hd + movimientos.idMovimiento + ".pdf";
                //document.Save(save2);
                document.Save(stream);

                SaveStreamAsFileNAME("C:/Inventarios", document, save2);
               
                //Close the document.
                document.Close(true);

              

                byte[] bytes = stream.ToArray();


                bool res = SendSTMPT(bytes, correo);


                if (tipomov == 1)
                {
                    hd = "OrdendeEntrada";
                }
                if (tipomov == 2)
                {
                    hd = "OrdendeSalida";
                }

                string save = hd + movimientos.idMovimiento+".pdf";

                Process.Start("C:/Inventarios/"+ save2);

                //System.Diagnostics.Process.Start(@ class="hljs-string">"c:/myPDF.pdf");

                //string pdfPath = Path.Combine(Application.StartupPath, "archivo.pdf");

                //Process.Start(pdfPath);
                

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }

            using (FileStream fs = new FileStream(Path.Combine(filePath, fileName), FileMode.CreateNew, FileAccess.Write))
            {
                
                //fs.Close();
                CopyStream(inputStream, fs);
            }

            inputStream.Close();
            inputStream.Flush();


        }


        public void SaveStreamAsFileNAME(string filePath, PdfDocument document, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }

            document.Save(filePath+"/"+fileName);


        }

        private async Task MainTask()
        {
            DataTable tablacarrito;
            tablacarrito = new DataTable();
            try
            {
                List<Movimientos> lista = await queryData(IdSalida);

                if (lista == null)
                {
                    return;
                }

                if (lista.Count == 0) {
                    
                    return;
                }

                User Usuario = lista[0].usuario;
                //fill table
                correo = Usuario.correo;
                if (Usuario==null)
                {
                    correo = CurrentUsers.correo;
                }

                tablacarrito.Columns.Add("CANT", typeof(string));
                tablacarrito.Columns.Add("CODIGO", typeof(string));
                tablacarrito.Columns.Add("DESCRP", typeof(string));
                tablacarrito.Columns.Add("MARCA", typeof(string));
                tablacarrito.Columns.Add("MODELO", typeof(string));
                tablacarrito.Columns.Add("SERIE", typeof(string));



                foreach (Movimientos mov in lista)
                {

                    tablacarrito.Rows.Add(mov.dispositivo.cantidad, mov.dispositivo.codigo, mov.dispositivo.producto, mov.dispositivo.marca, mov.dispositivo.modelo, mov.dispositivo.serie);
                }


                CreatePDF(lista[0], tablacarrito, Usuario, lista[0].tipoMovId);
                tablacarrito.Dispose();

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Ocurrio alguno error en la consulta de movimientos");
            }


        }

        private async Task<List<Movimientos>> queryData(string IDsalida)
        {
            try
            {
                QueryMovimientos hist = new QueryMovimientos();
                hist.idMovimiento = IDsalida;

                List<Movimientos> historial = new List<Movimientos>();

                //var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.ID == IDsalida).ToListAsync();
                string json = JsonConvert.SerializeObject(hist,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "movimientos/query";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);

                if (statusmessage.statuscode == 500)
                {
                    MessageBox.Show("Error interno en el servidor, obtencion de movimientos");
                }

                if (statusmessage.statuscode == 409)
                {
                    MessageBox.Show("Ocurrio un conflicto duarante la consulta de movimentos");
                }

                if (statusmessage.statuscode == 400)
                {
                    MessageBox.Show("No hay campos seleccionados a consultar");
                }

                if (statusmessage.statuscode == 404)
                {
                    MessageBox.Show("Movimientos NO encontrados");
                }

                if (statusmessage.statuscode == 200)
                {
                    historial = JsonConvert.DeserializeObject<List<Movimientos>>(statusmessage.data);

                    for (int x = 0; x < historial.Count; x++)
                    {
                        Devices dispositivo = historial[x].dispositivo;
                        historial[x].dispositivo_Actual = dispositivo.producto;
                        historial[x].codigo_Actual = dispositivo.codigo;

                        User usuario = historial[x].usuario;
                        historial[x].nombre_Actual = usuario.nombre + " " + usuario.apellidoPaterno + "" + usuario.apellidoMaterno;

                        TipoMovimiento tipoMovimiento = historial[x].tipoMovimiento;
                        historial[x].tipo_Actual = tipoMovimiento.tipo;
                    }

                   
                }

                return historial;

            }
            catch
            {
                return null;
            }
            // searching only idproduct


        }

       

        private bool SendSTMPT(byte[] bytes, string correo)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("avsinventario@gmail.com");
                mail.To.Add(correo);
                mail.Subject = "Orden de salida";
                mail.Body = "AVS Orden de salida, no responder";
                System.Net.Mail.Attachment attachment;

                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType();
                ct.MediaType = MediaTypeNames.Application.Pdf;
                ct.Name = "output " + DateTime.Now.ToString() + ".pdf";

                attachment = new System.Net.Mail.Attachment(new MemoryStream(bytes), ct);
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("avsinventario@gmail.com", "avs123456");
                SmtpServer.Send(mail);



                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
        
                MessageBox.Show("Ocurrio un error en el envio del correo");
                return false;
            }



        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
