namespace SA45Team02_SSIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [StringLength(50)]
        public string Department_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Department_Name { get; set; }

        public int HeadStaff_ID { get; set; }

        public int Representative_ID { get; set; }

        public int Phone { get; set; }

        public int CollectionPoint_ID { get; set; }

        public int ContactStaff_ID { get; set; }

        public virtual CollectionPoint CollectionPoint { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Employee Employee2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
