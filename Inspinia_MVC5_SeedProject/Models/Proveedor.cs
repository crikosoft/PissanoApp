using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Proveedor
    {
        public int proveedorId { get; set; }

        [Required()]
        [Display(Name = "Razón Social")]
        public string razonSocial { get; set; }

        [StringLength(500)]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [StringLength(200)]
        [Display(Name = "Representante de Ventas")]
        public string representanteVentas { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Celular")]
        public string movil { get; set; }

        [StringLength(100)]
        [Display(Name = "Número de Cuenta")]
        public string numeroCuenta { get; set; }        

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Required()]
        public string ruc { get; set; }

        public virtual List<OrdenCompra> OrdenCompras { get; set; }


        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        public DateTime fechaCreacion { get; set; }

        public DateTime fechaModificacion { get; set; }

        public virtual List<CuentaBancaria> CuentasBancarias { get; set; }
    }
}