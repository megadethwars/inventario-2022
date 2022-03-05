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
        public int Cantidad { get; set; }

        [DefaultValue(null)]
        public string Codigo { get; set; }

        [DefaultValue(null)]
        public string Compra { get; set; }

        [DefaultValue(0)]
        public int Costo { get; set; }

        [DefaultValue(null)]
        public string Descompostura { get; set; }

        [DefaultValue(null)]
        public DateTime? FechaAlta { get; set; }

        [DefaultValue(null)]
        public DateTime? FechaUltimaModificacion { get; set; }

        [DefaultValue(null)]
        public string Foto { get; set; }

        [DefaultValue(0)]
        public int Id { get; set; }

        [DefaultValue(null)]
        public string IdMov { get; set; }


        [DefaultValue(null)]
        public string Lugar_Actual { get; set; }
        
        [DefaultValue(null)]
        public Lugares lugar { get; set; }
        

        [DefaultValue(null)]
        public string lugarId { get; set; }
        
        [DefaultValue(null)]
        public string Marca { get; set; }
        
        [DefaultValue(null)]
        public string Modelo { get; set; }

        [DefaultValue(null)]
        public string Observaciones { get; set; }

        [DefaultValue(null)]
        public string Origen { get; set; }

        [DefaultValue(null)]
        public string Pertenece { get; set; }

        [DefaultValue(null)]
        public string Producto { get; set; }

        [DefaultValue(null)]
        public string Proveedor { get; set; }


        [DefaultValue(null)]
        public string StatusActual { get; set; }

        [DefaultValue(null)]
        public StatusDevices status { get; set; }
    }
}
