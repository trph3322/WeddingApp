//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WeddingDatabaseEntities : DbContext
    {
        public WeddingDatabaseEntities()
            : base("name=WeddingDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BALLROOM> BALLROOMS { get; set; }
        public virtual DbSet<BALLROOMTYPE> BALLROOMTYPES { get; set; }
        public virtual DbSet<DISH> DISHES { get; set; }
        public virtual DbSet<DISHTYPE> DISHTYPES { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<FUNCTION> FUNCTIONS { get; set; }
        public virtual DbSet<INVOICE> INVOICES { get; set; }
        public virtual DbSet<MENU> MENUS { get; set; }
        public virtual DbSet<PARAMETER> PARAMETERS { get; set; }
        public virtual DbSet<PERMISSION> PERMISSIONs { get; set; }
        public virtual DbSet<REPORTDETAIL> REPORTDETAILS { get; set; }
        public virtual DbSet<ROLE> ROLES { get; set; }
        public virtual DbSet<SALESREPORT> SALESREPORTS { get; set; }
        public virtual DbSet<SERVICE> SERVICES { get; set; }
        public virtual DbSet<SHIFT> SHIFTS { get; set; }
        public virtual DbSet<USEDSERVICE> USEDSERVICES { get; set; }
        public virtual DbSet<WEDDING> WEDDINGS { get; set; }
    }
}
