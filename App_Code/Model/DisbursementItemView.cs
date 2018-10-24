namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DisbursementItemView")]
    public partial class DisbursementItemView
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
        [StringLength(50)]
        public string Department_Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string collectionPoint { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Employee_Name { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuantityToGiveOut { get; set; }

        public DateTime? Disbursement_Date { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Disbursement_Status { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Retrieval_ID { get; set; }
    }
}
