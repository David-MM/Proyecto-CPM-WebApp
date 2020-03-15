using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class OrdenComparModel
    {
        public int? IdUsario { get; set; }

        [Display(Name = "Proveedor")]
        public int? IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        [Display(Name = "Fecha de Vencimineto")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Bodega")]
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        [Display(Name = "Precio")]
        public double Valor { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Display(Name = "ISV %")]
        public double ISV { get; set; }
        public double Subtotal { get; set; }
        public double ISVTotal { get; set; }
        public double Total { get; set; }

        public List<OrdenCompraDetalleModel> DetalleOrendenCompra { get; set; }
    }
}