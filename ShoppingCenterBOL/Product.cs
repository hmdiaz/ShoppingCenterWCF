using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string ProductDescription { get; set; }

        [StringLength(100)]
        public string ProductImage { get; set; }

        [ForeignKey("Provider")]
        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ProductInfo ProductInfo { get; set; }
    }
}
