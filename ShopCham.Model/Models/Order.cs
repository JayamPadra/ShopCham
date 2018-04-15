using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCham.Model
{
    [Table("Orders")]
    public class Order : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        [MaxLength(50)]
        public string PaymentMenthod { get; set; }

        [MaxLength(50)]
        public string PaymentStatus { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
