using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class BancoModel
    {
        
        public int IdBanco { get; set; }
        [Display(Name = "Nombre del Banco")]
        [Required(ErrorMessage ="El nombre del Banco es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-Mail del Proveedor Requerido")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
    }
}