using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class CurrentUsers
    {
       
        public static string apellidoMaterno { get; set; }

       
        public static string apellidoPaterno { get; set; }


        public static string correo { get; set; }


        public static DateTime fechaAlta { get; private set; }


        public static DateTime fechaUltimaModificacion { get; private set; }


        public static string foto { get; set; }


        public static int id { get; set; }

    
        public static string nombre { get; set; }

    
        public static int rolId { get; set; }


        public static int statusId { get; set; }

     
        public static string telefono { get; set; }

      
        public static string username { get; set; }

   
        public static string password { get; set; }

        
        public static string statusUserDescripcion { get; set; }

        

        public static Rol rol  { get;set; }
    }
}
