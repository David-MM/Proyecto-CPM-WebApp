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
    
    public partial class BODEGA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BODEGA()
        {
            this.COMPRADETALLE = new HashSet<COMPRADETALLE>();
            this.EXISTENCIA = new HashSet<EXISTENCIA>();
            this.PRODUCCIONDETALLE = new HashSet<PRODUCCIONDETALLE>();
            this.TRANSACCION = new HashSet<TRANSACCION>();
            this.VENTADETALLE = new HashSet<VENTADETALLE>();
        }
    
        public int IdBodega { get; set; }
        public int IdUsuario { get; set; }
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
    
        public virtual CIUDAD CIUDAD { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRADETALLE> COMPRADETALLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXISTENCIA> EXISTENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCCIONDETALLE> PRODUCCIONDETALLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSACCION> TRANSACCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTADETALLE> VENTADETALLE { get; set; }
    }
}
