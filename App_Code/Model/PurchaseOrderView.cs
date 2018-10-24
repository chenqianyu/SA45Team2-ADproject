namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderView")]
    public partial class PurchaseOrderView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PO_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Supplier_Name { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime PO_Date { get; set; }
    }
}
