using System.Collections.Generic;

namespace COMPRAS2.modelos
{
    public class MovementStatusResponse
    {
        public string idMovimiento { get; set; }
        public string status { get; set; }
        public int requested_devices { get; set; }
        public List<int> failed_devices { get; set; }
        public List<int> processed_devices { get; set; }
        public List<int> skipped_devices { get; set; }
    }
}
