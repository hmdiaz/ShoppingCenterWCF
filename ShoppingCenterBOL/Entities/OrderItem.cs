using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCenterBOL.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public decimal ItemPrice { get; set; }

        //----------------Navigation Property----------------//
        public Product Product { get; set; }
    }
}
