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
    
    public partial class COBRO
    {
        public int IdCobro { get; set; }
        public int IdDeposito { get; set; }
        public int IdVenta { get; set; }
        public double ValorPagado { get; set; }
    
        public virtual DEPOSITO DEPOSITO { get; set; }
        public virtual VENTA VENTA { get; set; }
    }
}
