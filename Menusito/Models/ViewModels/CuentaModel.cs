using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class CuentaModel
    {
        public int IdCuenta { get; set; }
        [Display(Name = "Seleccione un Banco")]
        public int IdBanco { get; set; }
        public string NombreBanco { get; set; }
        [Display(Name = "Saldo")]
        public double Saldo { get; set; }
        [Display(Name = "Numero de la Cuenta")]
        public string NCuenta { get; set;  }

    }
}