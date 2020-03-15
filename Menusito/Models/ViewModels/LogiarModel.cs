using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class LogiarModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Usuario Requerido")]
        [StringLength(50)]
        [Display (Name = "Usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo Contraseña Requerido")]
        [StringLength(50)]
        [Display (Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string mensaje { get; set; }
    }
}