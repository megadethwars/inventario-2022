using System;

namespace COMPRAS2.modelos
{
    public class StatusDTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaUltimaModificacion { get; set; }
    }
}
