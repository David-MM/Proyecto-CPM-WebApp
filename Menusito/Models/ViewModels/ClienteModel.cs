using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class ClienteModel
    {

        public Nullable<int> IdCliente { get; set; }

        [Display(Name = "Nombre del Cliente")]
        [Required(ErrorMessage = "Nobre del Cliente Requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }

        [Display(Name = "Telefono")]
        [StringLength(50)]
        public string Telefono { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-Mail del Proveedor Requerido")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Display(Name = "Nombre del Contacto")]
        public string Contacto { get; set; }
        public Nullable<double> LimCredito { get; set; }
        [Display(Name = "Descuento")]
        public Nullable<double> Descuento { get; set; }
        public Nullable<double> DeudaPagar { get; set; }
        public Nullable<double> CreditoDisponible { get; set; }
        public string Estado { get; set; }
    }
}