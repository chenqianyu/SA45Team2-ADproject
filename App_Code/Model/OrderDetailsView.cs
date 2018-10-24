namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetailsView")]
    public partial class OrderDetailsView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Item_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Supplier_Name { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ordered_Qty { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PO_No { get; set; }
    }
}
