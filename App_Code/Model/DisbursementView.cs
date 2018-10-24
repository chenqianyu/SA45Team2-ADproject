namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DisbursementView")]
    public partial class DisbursementView
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuantityToGiveOut { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_ID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Department_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Department_Name { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requested_Qty { get; set; }

        public int? Actual_Qty { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Retrieval_Date { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Retrieval_ID { get; set; }

        public DateTime? Approval_Timestamp { get; set; }
    }
}
