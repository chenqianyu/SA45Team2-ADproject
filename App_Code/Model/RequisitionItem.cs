namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequisitionItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Item_No { get; set; }

        public int Requested_Qty { get; set; }

        public int? Actual_Qty { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual ItemCatalog ItemCatalog { get; set; }

        public virtual Requisition Requisition { get; set; }
    }
}
