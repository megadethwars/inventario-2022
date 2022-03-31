using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace COMPRAS2.modelos
{
    public class Movimientos
    {
        [DefaultValue(0)]
        public int dispositivoId { get; set; }
        [DefaultValue(0)]
        public int usuarioId { get; set; }
        [DefaultValue(0)]
        public int LugarId { get; set; }
        [DefaultValue(null)]
        public string idMovimiento { get; set; }
        [DefaultValue(null)]
        public string comentarios { get; set; }
        [DefaultValue(0)]
        public int tipoMovId { get; set; }
        [DefaultValue(null)]

        public string foto { get; set; }

        [DefaultValue(null)]
        public string foto2 { get; set; }

        [DefaultValue(null)]
        public DateTime? fechaAlta = null;

        [DefaultValue(null)]
        public DateTime? fechaUltimaModificacion = null;

        [DefaultValue(null)]
        public Devices dispositivo;

        //public User usuario;




    }
}
