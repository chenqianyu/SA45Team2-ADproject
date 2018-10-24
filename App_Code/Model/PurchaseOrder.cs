namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrder")]
    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int PO_No { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier_ID { get; set; }

        public int Employee_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime PO_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Approval_Date { get; set; }

        public int? Approved_By { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expected_Delivery_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Actual_Delivery_Date { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
