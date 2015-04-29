using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL
{
    public class ProductInfo
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ViewTimes { get; set; }

        public int BuyTimes { get; set; }
    }
}
