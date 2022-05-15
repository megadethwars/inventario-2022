using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace COMPRAS2.modelos
{
    public class QueryReporte
    {
        [DefaultValue(0)]
        public int dispositivoId { get; set; }

        [DefaultValue(null)]
        public string dispositivoActual { get; set; }

        [DefaultValue(null)]
        public string UserActual { get; set; }

        [DefaultValue(null)]
        public string producto { get; set; }

        [DefaultValue(null)]
        public string codigo { get; set; }
    }
}
