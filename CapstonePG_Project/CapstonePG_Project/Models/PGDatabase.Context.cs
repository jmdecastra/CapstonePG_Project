﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapstonePG_Project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PGDatabase : DbContext
    {
        public PGDatabase()
            : base("name=PGDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CycleFrequency> CycleFrequencies { get; set; }
        public DbSet<MachineTiming> MachineTiming { get; set; }
        public DbSet<ObservationAssignment> ObservationAssignments { get; set; }
        public DbSet<ObservationSheet> ObservationSheets { get; set; }
        public DbSet<ObservationTransaction> ObservationTransactions { get; set; }
        public DbSet<PreferredMethod> PreferredMethods { get; set; }
        public DbSet<PrefMethLine> PrefMethLines { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseMethod> WarehouseMethods { get; set; }
    }
}
