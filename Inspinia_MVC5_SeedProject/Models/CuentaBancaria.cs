using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class CuentaBancaria
    {
        public int cuentaBancariaId { get; set; }
        public int proveedorId { get; set; }
        public int monedaId { get; set; }
        public int bancoId { get; set; }

        [StringLength(100)]
        [Display(Name = "Número de Cuenta")]
        public string numeroCuenta { get; set; }

        [Display(Name = "Cuenta Default")]
        public bool cuentaDefault { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual Banco Banco { get; set; }

    }
}