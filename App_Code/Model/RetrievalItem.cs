namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RetrievalItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Retrieval_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Item_No { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        public DateTime? Disbursement_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Disbursement_Status { get; set; }

        public int QuantityToGiveOut { get; set; }

        public virtual ItemCatalog ItemCatalog { get; set; }

        public virtual Requisition Requisition { get; set; }

        public virtual Retrieval Retrieval { get; set; }
    }
}
