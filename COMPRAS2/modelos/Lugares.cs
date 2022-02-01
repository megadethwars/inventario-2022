using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    class Lugares
    {

        public bool activo { get; set; }

        [DefaultValue(null)]
        public DateTime fechaAlta { get; set; }

        [DefaultValue(null)]
        public DateTime fechaUltimaModificacion { get; set; }

        public string lugar { get; set; }
    }
}
