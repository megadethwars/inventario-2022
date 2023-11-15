using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace COMPRAS2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        ///  
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));
        [STAThread]
        
        static void Main()
        {
            string configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            // Inicializa log4net con la ruta al archivo de configuración
            log4net.Config.XmlConfigurator.Configure(new FileInfo(configFile));
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new INICIARSESION());
        }
    }
}
