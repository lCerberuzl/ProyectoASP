﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<almacenamiento> almacenamiento { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<detalle_venta> detalle_venta { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<fuente_poder> fuente_poder { get; set; }
        public virtual DbSet<gabinete> gabinete { get; set; }
        public virtual DbSet<inventario> inventario { get; set; }
        public virtual DbSet<marca> marca { get; set; }
        public virtual DbSet<memoria_ram> memoria_ram { get; set; }
        public virtual DbSet<paquete_ensamble> paquete_ensamble { get; set; }
        public virtual DbSet<procesador> procesador { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tarjeta_madre> tarjeta_madre { get; set; }
        public virtual DbSet<tarjeta_video> tarjeta_video { get; set; }
        public virtual DbSet<tipo_almacenamiento> tipo_almacenamiento { get; set; }
        public virtual DbSet<tipo_memoria> tipo_memoria { get; set; }
        public virtual DbSet<tipo_socket> tipo_socket { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<venta> venta { get; set; }
    }
}
