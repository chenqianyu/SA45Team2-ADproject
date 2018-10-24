namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Representative")]
    public partial class Representative
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_date { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
