namespace Admin
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Table")]
    public partial class Table
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        [StringLength(100)]
        public string ip { get; set; }

        
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength]
        public string userAgent { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        [StringLength(100)]
        public string sessionID { get; set; }
    }
}
