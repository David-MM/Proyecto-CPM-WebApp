using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class TransaccionModel
    {
        public int IdBodega { get; set; }
        public int? IdOrden { get; set; }
        public int IdPoducto { get; set; }
        public int IdUsuario { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public double Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int? Id { get; set; }
        public String Nombre { get; set; }

    }
}