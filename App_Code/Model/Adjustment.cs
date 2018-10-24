namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adjustment")]
    public partial class Adjustment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Item_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Raised_Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Remarks { get; set; }

        public int Quantity { get; set; }

        public int? Acknowledged_By { get; set; }

        public DateTime? Acknowledgement_Date { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual ItemCatalog ItemCatalog { get; set; }
    }
}
