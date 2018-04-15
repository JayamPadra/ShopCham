using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("Slides")]
    public class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string SlideName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Required]
        [MaxLength(256)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
    }
}
