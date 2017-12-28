namespace DatabaseCourse.CDMS.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CooperationContract")]
    public partial class CooperationContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CooperationContract()
        {
            Leave = new HashSet<Leave>();
        }

        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string WageType { get; set; }

        public int? ContractorId { get; set; }

        public int? ProjectId { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leave> Leave { get; set; }
    }
}
