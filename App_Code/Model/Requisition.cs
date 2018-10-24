namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Requisition")]
    public partial class Requisition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requisition()
        {
            RequisitionItems = new HashSet<RequisitionItem>();
            RetrievalItems = new HashSet<RetrievalItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        public int Employee_ID { get; set; }

        public DateTime? Approval_Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime Submission_Timestamp { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetrievalItem> RetrievalItems { get; set; }
    }
}
