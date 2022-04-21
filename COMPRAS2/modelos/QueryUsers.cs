﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class QueryUsers
    {
        [DefaultValue(0)]
        public int id { get; set; }

        [DefaultValue(null)]
        public string nombre { get; set; }

        [DefaultValue(null)]
        public string username { get; set; }

        [DefaultValue(null)]
        public string apellidoPaterno { get; set; }

        [DefaultValue(null)]
        public string apellidoMaterno { get; set; }
        
        [DefaultValue(null)]
        public string password { get; set; }

        [DefaultValue(null)]
        public string telefono { get; set; }

        [DefaultValue(null)]
        public string correo { get; set; }

        [DefaultValue(0)]
        public int rolId { get; set; }
       
        [DefaultValue(0)]
        public int statusId { get; set; }
    }
}