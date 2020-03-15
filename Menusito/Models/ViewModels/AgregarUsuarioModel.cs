using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class AgregarUsuarioModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Usuario")]
        [StringLength(50)]
        public string Usuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(50)]
        public string Contra { get; set; }
        [Display(Name ="Seleccione un Rol")]
        public int Rol { get; set; }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public int IdEmp { get; set; }
        public string NombreEmp { get; set; }
    }

}