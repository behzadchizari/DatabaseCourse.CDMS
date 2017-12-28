namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inspection")]
    public partial class Inspection
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Result { get; set; }

        public int? ProjectId { get; set; }

        public int? SupervisorEngId { get; set; }

        public virtual Project Project { get; set; }

        public virtual SupervisorEngineer SupervisorEngineer { get; set; }
    }
}
