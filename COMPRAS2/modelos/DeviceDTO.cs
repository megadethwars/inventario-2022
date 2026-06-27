using System;

namespace COMPRAS2.modelos
{
    public class DeviceDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string producto { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string origen { get; set; }
        public string foto { get; set; }
        public int cantidad { get; set; }
        public string observaciones { get; set; }
        public int lugarId { get; set; }
        public string pertenece { get; set; }
        public string descompostura { get; set; }
        public int? costo { get; set; }
        public string compra { get; set; }
        public string proveedor { get; set; }
        public string idMov { get; set; }
        public int statusId { get; set; }

        // Objetos anidados del JSON
        public LugarDTO lugar { get; set; }
        public StatusDTO status { get; set; }

        public DateTime fechaAlta { get; set; }
        public DateTime fechaUltimaModificacion { get; set; }
        public string serie { get; set; }
        public string accesorios { get; set; }

        // Método para convertir DeviceDTO a Devices
        public Devices ToDevices()
        {
            return new Devices
            {
                id = this.id,
                codigo = this.codigo,
                producto = this.producto,
                marca = this.marca,
                modelo = this.modelo,
                origen = this.origen,
                foto = this.foto,
                cantidad = this.cantidad,
                observaciones = this.observaciones,
                lugarId = this.lugarId,
                pertenece = this.pertenece,
                descompostura = this.descompostura,
                costo = this.costo ?? 0,
                compra = this.compra,
                proveedor = this.proveedor,
                idMov = this.idMov,
                statusId = this.statusId,
                fechaAlta = this.fechaAlta,
                fechaUltimaModificacion = this.fechaUltimaModificacion,
                serie = this.serie,
                accesorios = this.accesorios
            };
        }
    }
}
