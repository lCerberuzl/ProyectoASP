//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class gabinete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gabinete()
        {
            this.paquete_ensamble = new HashSet<paquete_ensamble>();
        }
    
        public int id_gabinete { get; set; }
        public string nombre_gabinete { get; set; }
        public string descripcion_gabinete { get; set; }
        public string factorforma_gabinete { get; set; }
        public bool estatus_gabinete { get; set; }
        public int id_inventario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paquete_ensamble> paquete_ensamble { get; set; }
        public virtual inventario inventario { get; set; }
    }
}
