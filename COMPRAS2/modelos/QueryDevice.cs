using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace COMPRAS2.modelos
{
    public class QueryDevice
    {

        [DefaultValue(0)]
        public int id { get; set; }

        [DefaultValue(null)]
        public string codigo { get; set; }

    }
}
