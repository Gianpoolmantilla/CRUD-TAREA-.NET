//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apnetTareasMVC_CRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BaseTareasSEntities : DbContext
    {
        public BaseTareasSEntities()
            : base("name=BaseTareasSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PRIORIDAD> PRIORIDAD { get; set; }
        public virtual DbSet<TAREAS> TAREAS { get; set; }
        public virtual DbSet<TIPO> TIPO { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
    }
}
