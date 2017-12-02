namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        public int Id { get; set; }

        public int? User_Id { get; set; }

        public int? Role_Id { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
