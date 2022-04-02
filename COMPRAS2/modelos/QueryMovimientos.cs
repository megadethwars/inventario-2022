using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    class QueryMovimientos
    {
        [DefaultValue(0)]
        public int dispositivoId { get; set; }

        [DefaultValue(0)]
        public int usuarioId { get; set; }

        [DefaultValue(0)]
        public int LugarId { get; set; }
        /*
        [DefaultValue(null)]
        public DateTime? fechaAlta { get; set; }
        */
        [DefaultValue(null)]
        public string idMovimiento { get; set; }

        [DefaultValue(0)]
        public int tipoMovId { get; set; }
  
    }
}
