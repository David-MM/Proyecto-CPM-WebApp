using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class OrdenCompraDetalleModel
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdBodega { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
        public double ISV { get; set; }
        public double SubTotal { get; set; }

    }
}