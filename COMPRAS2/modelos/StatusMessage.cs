using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class StatusMessage
    {
        [DefaultValue(0)]
        public int statuscode { get; set; }

        [DefaultValue(null)]
        public string message { get; set; }

        [DefaultValue(null)]
        public string data { get; set; }
    }


    public class ErrorMessage
    {
        [DefaultValue(0)]
        public int statuscode { get; set; }

        [DefaultValue(null)]
        public string message { get; set; }

        [DefaultValue(null)]
        public string data { get; set; }
    }

}
