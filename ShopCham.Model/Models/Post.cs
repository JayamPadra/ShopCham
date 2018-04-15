using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string PostName { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public int PostCategoryID { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        [ForeignKey("PostCategoryID")]
        public virtual PostCategory PostCategory { get; set; }
    }
}
