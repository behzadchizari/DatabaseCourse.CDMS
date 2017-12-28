namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expense")]
    public partial class Expense
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Seller { get; set; }

        [StringLength(50)]
        public string Buyer { get; set; }

        public bool? IsSubmitted { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ProjectId { get; set; }

        public int? GoodId { get; set; }

        public virtual Good Good { get; set; }

        public virtual Project Project { get; set; }
    }
}
