﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    
    public class Devices
    {
        [DefaultValue(0)]
        public int cantidad { get; set; }

        [DefaultValue(null)]
        public string codigo { get; set; }

        [DefaultValue(null)]
        public string compra { get; set; }

        [DefaultValue(0)]
        public int costo { get; set; }

        [DefaultValue(null)]
        public string descompostura { get; set; }

        [DefaultValue(null)]
        public DateTime? FechaAlta { get; set; }

        [DefaultValue(null)]
        public DateTime? FechaUltimaModificacion { get; set; }

        [DefaultValue(null)]
        public string Foto { get; set; }

        [DefaultValue(0)]
        public int Id { get; set; }

        [DefaultValue(null)]
        public string IdMov { get; set; }


        [DefaultValue(null)]
        public string Lugar_Actual { get; set; }
        
        [DefaultValue(null)]
        public Lugares lugar { get; set; }
        

        [DefaultValue(null)]
        public string lugarId { get; set; }
        
        [DefaultValue(null)]
        public string marca { get; set; }
        
        [DefaultValue(null)]
        public string modelo { get; set; }

        [DefaultValue(null)]
        public string observaciones { get; set; }

        [DefaultValue(null)]
        public string Origen { get; set; }

        [DefaultValue(null)]
        public string Pertenece { get; set; }

        [DefaultValue(null)]
        public string producto { get; set; }

        [DefaultValue(null)]
        public string proveedor { get; set; }


        [DefaultValue(null)]
        public string StatusActual { get; set; }

        [DefaultValue(null)]
        public StatusDevices status { get; set; }


        [DefaultValue(null)]
        public string statusId { get; set; }
    }
}
