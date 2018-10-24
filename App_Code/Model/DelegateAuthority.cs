namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DelegateAuthority")]
    public partial class DelegateAuthority
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DelegateAuthority()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int Delegate_ID { get; set; }

        public int Employee_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Remarks { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
