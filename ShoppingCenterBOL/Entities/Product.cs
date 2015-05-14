using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL.Entities
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

        //----------------Navigation Property----------------//
        public Provider Provider { get; set; }

        public Category Category { get; set; }

        public ProductInfo ProductInfo { get; set; }
    }
}