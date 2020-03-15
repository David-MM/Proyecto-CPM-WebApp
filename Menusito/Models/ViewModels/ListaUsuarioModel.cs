using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menusito.Models.ViewModels
{
    public class ListaUsuarioModel
    {

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contra { get; set; }
        public int? Estado { get; set; }
    }
}