using System;

namespace COMPRAS2.modelos
{
    public class LugarDTO
    {
        public int id { get; set; }
        public string lugar { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaUltimaModificacion { get; set; }
        public bool activo { get; set; }
    }
}
