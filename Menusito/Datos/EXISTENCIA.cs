//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Menusito.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class EXISTENCIA
    {
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public int Cantidad { get; set; }
    
        public virtual BODEGA BODEGA { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
