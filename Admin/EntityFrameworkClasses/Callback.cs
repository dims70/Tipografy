namespace Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Callback")]
    public partial class Callback
    {
        [Key]
        public int idCallback { get; set; }

        public int idUser { get; set; }

        [Required]
        public string Question { get; set; }

        public virtual Users Users { get; set; }
    }
}
