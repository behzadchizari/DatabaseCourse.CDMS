namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CDMSEntities : DbContext
    {
        public CDMSEntities()
            : base("name=CDMSEntities")
        {
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var f= modelBuilder.Entity<Role>().Property(u => u.Title).HasColumnName("title");
        }
    }
}
