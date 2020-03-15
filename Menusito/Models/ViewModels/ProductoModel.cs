using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }

        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "Nombre del Producto Requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Display(Name = "Existencia Minima del Proveedor")]
        [Required(ErrorMessage = "Existencia Minima Requerida")]
        public int ExistenciaMinima { get; set; }

        [Display(Name = "Precio del Proveedor")]
        [Required(ErrorMessage = "Precio del Proveedor Requerido")]
        public double Precio { get; set; }
    }
}