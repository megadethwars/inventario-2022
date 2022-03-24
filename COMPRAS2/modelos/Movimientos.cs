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
        [DefaultValue(0)]
        public int idMovimiento { get; set; }
        [DefaultValue(null)]
        public string comentarios { get; set; }
        [DefaultValue(0)]
        public int tipoMovId { get; set; }
        [DefaultValue(null)]

        public string foto { get; set; }

        [DefaultValue(null)]
        public string foto2 { get; set; }

  
        public DateTime? fechaAlta = null;


        public DateTime? fechaUltimaModificacion = null;




    }
}
