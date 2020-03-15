using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class BodegaModel
    {
        public int IdBodega { get; set; }
        [Display(Name = "Nombre de la Bodega.")]
        public string Nombre { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        public string Estado { get; set; }

        [Display(Name = "Ciudad")]
        public int IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        [Display(Name = "Pais")]
        public int IdPais { get; set; }
        public string NombrePais { get; set; } 
    }
}
