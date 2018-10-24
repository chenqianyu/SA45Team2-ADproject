namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockCardView")]
    public partial class StockCardView
    {
        [Column("Item Number")]
        [StringLength(50)]
        public string Item_Number { get; set; }

        public int? Quantity { get; set; }

        public DateTime? Date { get; set; }

        [Column("PO Number")]
        public int? PO_Number { get; set; }

        [Column("Disbursement ID")]
        [StringLength(63)]
        public string Disbursement_ID { get; set; }

        [Key]
        [Column("Transaction Type")]
        [StringLength(18)]
        public string Transaction_Type { get; set; }
    }
}
