using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class Reportes
    {
        [DefaultValue(null)]
        public string comentarios { get; set; }


        [DefaultValue(null)]
        public string dispositivoCodigo { get; set; }

        [DefaultValue(null)]
        public string dispositivoActual { get; set; }
        
        [DefaultValue(null)]
        public Devices dispositivo { get; set; }
        

        [DefaultValue(0)]
        public int dispositivoId { get; set; }

        [DefaultValue(null)]
        public DateTime? fechaAlta { get; set; }

        [DefaultValue(null)]
        public DateTime? fechaUltimaModificacion { get; set; }

        [DefaultValue(null)]
        public string foto { get; set; }

        [DefaultValue(0)]
        public int id { get; set; }

        
        [DefaultValue(null)]
        public string UserActual { get; set; }
        
        [DefaultValue(null)]
        public string UserActualA { get; set; }

        [DefaultValue(null)]
        public User usuario { get; set; }     

        [DefaultValue(null)]
        public int usuarioId { get; set; }
    }
}
