using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    
    public class Devices
    {
        [DefaultValue(0)]
        public int cantidad { get; set; }

        [DefaultValue(null)]
        public string codigo { get; set; }

        [DefaultValue(null)]
        public string compra { get; set; }

        [DefaultValue(0)]
        public int costo { get; set; }

        [DefaultValue(null)]
        public string descompostura { get; set; }

        [DefaultValue(null)]
        public DateTime? fechaAlta { get; set; }

        [DefaultValue(null)]
        public DateTime? fechaUltimaModificacion { get; set; }

        [DefaultValue(null)]
        public string foto { get; set; }

        [DefaultValue(0)]
        public int id { get; set; }

        [DefaultValue(null)]
        public string idMov { get; set; }


        [DefaultValue(null)]
        public string Lugar_Actual { get; set; }
        
        [DefaultValue(null)]
        public Lugares lugar { get; set; }
        

        [DefaultValue(0)]
        public int lugarId { get; set; }
        
        [DefaultValue(null)]
        public string marca { get; set; }
        
        [DefaultValue(null)]
        public string modelo { get; set; }

        [DefaultValue(null)]
        public string observaciones { get; set; }

        [DefaultValue(null)]
        public string origen { get; set; }

        [DefaultValue(null)]
        public string pertenece { get; set; }

        [DefaultValue(null)]
        public string producto { get; set; }

        [DefaultValue(null)]
        public string proveedor { get; set; }

        [DefaultValue(null)]
        public string serie { get; set; }


        [DefaultValue(null)]
        public string StatusActual { get; set; }

        [DefaultValue(null)]
        public StatusDevices status { get; set; }


        [DefaultValue(0)]
        public int statusId { get; set; }

        [DefaultValue(null)]
        public string accesorios { get; set; }

        
}
}
