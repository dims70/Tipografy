namespace Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        public int idOrder { get; set; }

        public int idUser { get; set; }

        public DateTime Date { get; set; }

        public int idSketch { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int idTypeDelivery { get; set; }

        [Column(TypeName = "money")]
        public decimal Sum { get; set; }

        public string Description { get; set; }

        public virtual Sketchs Sketchs { get; set; }

        public virtual TypeDelivery TypeDelivery { get; set; }

        public virtual Users Users { get; set; }
    }
}
