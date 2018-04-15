using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ShopCham.Model
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }
        public int ProductCategoryID { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }
        public XElement MoreImages { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }
        
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
