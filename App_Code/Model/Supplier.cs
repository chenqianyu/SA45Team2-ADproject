namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            SupplierItems = new HashSet<SupplierItem>();
        }

        [Key]
        [StringLength(50)]
        public string Supplier_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact_Name { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierItem> SupplierItems { get; set; }
    }
}
