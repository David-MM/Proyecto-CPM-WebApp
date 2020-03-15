using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class ChequeModel
    {
        public int IdCheque { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        [Display(Name = "Cuenta")]
        public int IdCuenta { get; set; }
        public string NCuenta { get; set; }
        [Display(Name = "Nombre del Proveedor")]
        public int? Idproveedor { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Valor del Cheque")]
        public double Valor { get; set; }
        public string Descripcion { get; set; }
        public string NombreBanco { get; set; }
    }
}