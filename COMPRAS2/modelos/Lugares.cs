using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class Lugares
    {
        [DefaultValue(null)]
        public bool activo { get; set; }
        
        public DateTime? fechaAlta { get; set; }
        
        public DateTime? fechaUltimaModificacion { get; set; }

        [DefaultValue(null)]
        public string lugar { get; set; }

        [DefaultValue(0)]
        public int id { get; set; }
    }
}
