﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDBFirstDemo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelFirstDemoDBEntities : DbContext
    {
        public ModelFirstDemoDBEntities()
            : base("name=ModelFirstDemoDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Enrollments> Enrollments { get; set; }
        public virtual DbSet<Students> Students { get; set; }
    }
}
