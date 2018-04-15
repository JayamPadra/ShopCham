using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string MenuName { get; set; }

        [MaxLength(256)]
        public string Url { get; set; }

        [MaxLength(10)]
        public string Target { get; set; }
        public int DisplayOrder { get; set; }
        public int GroupMenuID { get; set; }
        public bool Status { get; set; }

        [ForeignKey("GroupMenuID")]
        public virtual MenuGroup MenuGroup { get; set; }
    }
}
