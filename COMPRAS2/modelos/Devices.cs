using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    class Devices
    {
        public string codigo { get; set; }
        public string producto { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string origen { get; set; }
        public string foto { get; set; }
        public int cantidad { get; set; }
        public string observaciones { get; set; }
        public int lugarId { get; set; }
        public string pertenece { get; set; }
        public string descompostura { get; set; }
        public int costo { get; set; }
        public string compra { get; set; }
        public string proveedor { get; set; }
        public string idMov { get; set; }
    }
}
