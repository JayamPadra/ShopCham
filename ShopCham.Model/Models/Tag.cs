using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string TagCode { get; set; }

        [Required]
        [MaxLength(256)]
        public string TagName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string TagType { get; set; }
    }
}
