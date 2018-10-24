namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PO_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Item_No { get; set; }

        public int Ordered_Qty { get; set; }

        public int? Delivered_Qty { get; set; }

        public virtual ItemCatalog ItemCatalog { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
