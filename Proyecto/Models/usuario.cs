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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.cliente = new HashSet<cliente>();
            this.empleado = new HashSet<empleado>();
            this.proveedor = new HashSet<proveedor>();
        }
    
        public int id_usuario { get; set; }
        public string usuario1 { get; set; }
        public string password { get; set; }
        public bool estatus_usuario { get; set; }
        public int perfil_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public System.DateTime fechaNac_usuario { get; set; }
        public string email_usuario { get; set; }
        public string tel_usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleado> empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedor> proveedor { get; set; }
    }
}
