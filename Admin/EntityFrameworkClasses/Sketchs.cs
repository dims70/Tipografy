namespace Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sketchs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sketchs()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int idSketch { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int idTypeSketch { get; set; }

        [Required]
        [StringLength(50)]
        public string Material { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        public virtual TypesSketch TypesSketch { get; set; }
    }
}
