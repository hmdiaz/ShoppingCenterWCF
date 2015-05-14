using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL.Entities
{
    public class ProductInfo
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        [StringLength(100)]
        public string ProductImage { get; set; }

        public int AddToCartTimes { get; set; }

        public int BuyTimes { get; set; }

        //----------------Navigation Property----------------//
        public Product Product { get; set; }
    }
}
