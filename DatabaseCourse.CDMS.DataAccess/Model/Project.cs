namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        public int Id { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [StringLength(50)]
        public string GroundType { get; set; }

        [StringLength(50)]
        public string ProductionLicense { get; set; }

        public DateTime? EndingDate { get; set; }

        public int? UserId { get; set; }

        public int? SupervisorEngineerId { get; set; }

        [StringLength(50)]
        public string Client { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string GroundOwner { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
