namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Context;

    public partial class CDMSEntities : DbContext
    {
        public CDMSEntities()
            : base("name=CDMSEntities")
        {
        }

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<CooperationContract> CooperationContract { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Goods> Good { get; set; }
        public virtual DbSet<Inspection> Inspection { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<LogException> LogException { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SupervisorEngineer> SupervisorEngineer { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
