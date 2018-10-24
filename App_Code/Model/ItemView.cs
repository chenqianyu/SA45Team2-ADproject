namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemView")]
    public partial class ItemView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Requisition_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Department_Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Submission_Timestamp { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Employee_Name { get; set; }
    }
}
