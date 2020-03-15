using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class DepositoModel
    {
        public int IdDeposito { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        [Display(Name = "Cuenta")]
        public int IdCuenta { get; set; }
        public string NCuenta { get; set; }
        [Display(Name = "Nombre del Cliente")]
        public int? IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Valor del Deposito")]
        public double Valor { get; set; }
        public string Descripcion { get; set; }
        public string NombreBanco { get; set; }
    }
}