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

        public DateTime? RequestDate { get; set; }

        public int? ProjectId { get; set; }

        [StringLength(15)]
        public string Module { get; set; }

        public int? Amount { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public int? Price { get; set; }

        [StringLength(4000)]
        public string FinDescription { get; set; }

        [StringLength(50)]
        public string Goods { get; set; }
    }
}
