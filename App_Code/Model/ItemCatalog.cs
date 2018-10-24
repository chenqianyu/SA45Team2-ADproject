namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    [Table("ItemCatalog")]
    public partial class ItemCatalog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemCatalog()
        {
            Adjustments = new HashSet<Adjustment>();
            OrderDetails = new HashSet<OrderDetail>();
            RequisitionItems = new HashSet<RequisitionItem>();
            RetrievalItems = new HashSet<RetrievalItem>();
            SupplierItems = new HashSet<SupplierItem>();
        }

        [Key]
        [StringLength(50)]
        public string Item_No { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int Reorder_Lvl { get; set; }

        public int Reorder_Qty { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit_of_Measure { get; set; }

        public int Total_Qty { get; set; }

        public decimal Price { get; set; }

        public int Allocated_Qty { get; set; }

        public int Ordered_Qty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjustment> Adjustments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetrievalItem> RetrievalItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierItem> SupplierItems { get; set; }
    }
}
