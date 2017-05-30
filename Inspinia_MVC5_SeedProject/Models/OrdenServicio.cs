using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class OrdenServicio
    {
        public int ordenServicioId { get; set; }
        public int materialId { get; set; }
        public int proveedorId { get; set; }
        public double metrado { get; set; }
        public double precioUnitario { get; set; }
        public double subtotal { get; set; }
        public double igv { get; set; }
        public double total { get; set; }
        public int formaPagoId  { get; set; }
        public int monedaId  { get; set; }
        public double adelanto { get; set; }
        public double fondoGarantia { get; set; }
        public int MyProperty { get; set; }

    }
}