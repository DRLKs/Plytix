﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plytix
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class grupo11DBEntities : DbContext
    {
        public grupo11DBEntities()
            : base("name=grupo11DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CATEGORIA> CATEGORIA { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<CUENTA> CUENTA { get; set; }
        public DbSet<ATRIBUTO> ATRIBUTO { get; set; }
        public DbSet<PRODUCTO_ATRIBUTO> PRODUCTO_ATRIBUTO { get; set; }
        public DbSet<RELACION> RELACION { get; set; }
    }
}