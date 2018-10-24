namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequisitionRequest")]
    public partial class RequisitionRequest
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Item_No { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requested_Qty { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
