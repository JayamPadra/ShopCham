using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("Pages")]
    public class Page : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string PageName { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }
        public string Content { get; set; }
    }
}
