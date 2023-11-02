using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.modelos
{
    public class MovimientosDTO : Movimientos
    {
        public string nombre { get; set; }

        public string lugar { get; set; }

        public string producto { get; set; }

        public string tipo { get; set; }
    }
}   
