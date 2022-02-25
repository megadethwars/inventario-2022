using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    class StatusDevices
    {
        [DefaultValue(null)]
        public string descripcion { get; set; }

        public DateTime? fechaAlta { get; set; }

        public DateTime? fechaUltimaModificacion { get; set; }

        [DefaultValue(0)]
        public int id { get; set; }
    }
}
