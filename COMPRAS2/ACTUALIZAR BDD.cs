using COMPRAS2.servicios;
using ExcelDataReader;
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
            }
        }

        private void btnINICIAR_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fStream = File.Open(@"C:\File\Classes.xlsx", FileMode.Open, FileAccess.Read);
              


                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;


                IWorkbook workbook = application.Workbooks.Open(fStream);

                //Access first worksheet from the workbook.
                IWorksheet worksheet = workbook.Worksheets[1];

            }
            catch (Exception ex) { 
            }
        }
    }
}
