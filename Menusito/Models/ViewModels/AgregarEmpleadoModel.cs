using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class AgregarEmpleadoModel
    {
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int IdDeptoD { get; set; }
        public string NombreDepto { get; set; }
    }
}