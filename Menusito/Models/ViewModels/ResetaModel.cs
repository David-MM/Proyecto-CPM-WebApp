using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class ResetaModel
    {
        [Display(Name = "Producto a Producir")]
        public int IdProducto { get; set; }

        public int IdProductoE { get; set; }

        public int IdBodega { get; set; }

        public string NombreBodega { get; set; }
        public string Producto { get; set; }

        [Display(Name = "Cantidad a Producir")]
        public int Cantidad { get; set; }

        public List<RecetaDetalleModal> lstProductos { get; set; }

    }
}