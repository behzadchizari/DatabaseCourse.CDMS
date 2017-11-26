using System.Data.Entity;
using DatabaseCourse.CDMS.DataAccess.Model;

namespace DatabaseCourse.CDMS.DataAccess.Context
{
    public partial class CDMSEntities : DbContext
    {
        public CDMSEntities()
            : base("name=CDMSEntities1")
        {
        }

        public virtual DbSet<LogException> LogException { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRole)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LogException)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRole)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);
        }
    }
}
