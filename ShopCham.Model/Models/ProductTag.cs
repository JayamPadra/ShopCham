using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        public int ProductID { get; set; }

        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string TagCode { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("TagCode")]
        public virtual Tag Tag { get; set; }
    }
}
