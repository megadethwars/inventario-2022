using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class Reportes
    {
        [DefaultValue(null)]
        public string comentarios { get; set; }

        /*
        [DefaultValue(null)]
        public string DispositivoActual { get; set; }

        [DefaultValue(null)]
        public Devices status { get; set; }
        */

        [DefaultValue(0)]
        public int dispositivoId { get; set; }

        [DefaultValue(null)]
        public DateTime? FechaAlta { get; set; }

        [DefaultValue(null)]
        public DateTime? FechaUltimaModificacion { get; set; }

        [DefaultValue(null)]
        public string Foto { get; set; }

        [DefaultValue(0)]
        public int id { get; set; }

        /*
        [DefaultValue(null)]
        public string StatusActual { get; set; }

        [DefaultValue(null)]
        public StatusDevices status { get; set; }
        */

        [DefaultValue(null)]
        public int usuarioId { get; set; }
    }
}
