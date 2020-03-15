using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class ProveedorModel
    {

        public int ID { get; set; }

        [Display(Name = "Nombre del Proveedor")]
        [Required(ErrorMessage = "Nobre del Proveedor Requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string Proveedor { get; set; }

        public int IdC { get; set; }

        [StringLength(50)]
        public string Ciudad { get; set; }

        public int IdP { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }

        [Display(Name = "Nombre del Contacto con el Proveedor")]
        [Required(ErrorMessage = "Contacto del Proveedor Requerido")]
        [StringLength(50)]
        public string Contacto { get; set; }

        [Display(Name = "Numero Telefonico del Proveedor")]
        [Required(ErrorMessage = "Telefono del Proveedor Requerido")]
        [StringLength(50)]
        public string Telefono { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-Mail del Proveedor Requerido")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Display(Name = "Limete de credito que proporciona el Proveedor")]
        [Required(ErrorMessage = "Limiti de Credito Requerido")]
        public Double LimCredito { get; set; }

        public Double DeudaPagar { get; set; }

        public Double CreditoDisponible { get; set; }

        public int Descuento { get; set; }

    }
}