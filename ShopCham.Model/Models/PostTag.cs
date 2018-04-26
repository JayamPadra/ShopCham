using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 0)]
        public int PostID { get; set; }

        [Key]
        [MaxLength(50)]
        [Column(Order = 1,TypeName ="varchar")]
        public string TagCode { get; set; }

        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagCode")]
        public virtual Tag Tag { get; set; }
    }
}
