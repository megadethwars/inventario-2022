using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace COMPRAS2.modelos
{
    public class DeviceSomeFields
    {

        [DefaultValue(null)]
        public string codigo { get; set; }

        [DefaultValue(0)]
        public int id { get; set; }


        [DefaultValue(null)]
        public string lugar { get; set; }

        [DefaultValue(null)]
        public string modelo { get; set; }


        [DefaultValue(null)]
        public string producto { get; set; }


        [DefaultValue(null)]
        public string serie { get; set; }


        [DefaultValue(null)]
        public string descripcion { get; set; }

    }
}
