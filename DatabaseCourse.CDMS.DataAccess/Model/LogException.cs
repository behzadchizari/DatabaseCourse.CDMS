namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogException")]
    public partial class LogException
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Type { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime? DateTime { get; set; }

        public int? User_Id { get; set; }

        public int? User_Id1 { get; set; }

        public virtual User User { get; set; }
    }
}
