using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class Rol
    {
        [DefaultValue(null)]
        public string nombre { get; set; }

        public DateTime? fechaAlta = null;


        public DateTime? fechaUltimaModificacion = null;

        [DefaultValue(0)]
        public int id { get; set; }
    }
}
