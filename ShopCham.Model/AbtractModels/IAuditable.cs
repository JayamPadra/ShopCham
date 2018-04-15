using System;
using System.ComponentModel.DataAnnotations;

namespace ShopCham.Model
{
    interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        [MaxLength(256)]
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        [MaxLength(256)]
        string UpdatedBy { get; set; }
        bool Status { get; set; }
        [MaxLength(256)]
        string MetaKeyword { get; set; }
        [MaxLength(256)]
        string MetaDescription { get; set; }
    }
}
