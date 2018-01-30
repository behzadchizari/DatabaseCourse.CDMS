namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attachment")]
    public partial class Attachment
    { 
        public int Id { get; set; }

        [StringLength(150)]
        public string FileAddress { get; set; }

        [StringLength(50)]
        public string AttachmentCategory{ get; set; }

        [StringLength(50)]
        public string AttachmentType { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
