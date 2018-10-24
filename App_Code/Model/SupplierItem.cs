namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplierItem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Item_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Supplier_ID { get; set; }

        public decimal Price { get; set; }

        public int PreferenceRank { get; set; }

        public virtual ItemCatalog ItemCatalog { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
