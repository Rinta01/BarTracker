﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarTracker.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BarTrackerDBEntities : DbContext
    {
        public BarTrackerDBEntities()
            : base("name=BarTrackerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bars> Bars { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
    }
}