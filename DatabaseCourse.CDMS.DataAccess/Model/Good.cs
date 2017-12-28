namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Good")]
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            Expense = new HashSet<Expense>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        [StringLength(5)]
        public string Module { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expense> Expense { get; set; }
    }
}
