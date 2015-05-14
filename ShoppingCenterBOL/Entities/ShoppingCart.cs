using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int Count { get; set; }

        //----------------Navigation Property----------------//
        //Goods in Shopping Cart
        public Product Product { get; set; }

        //Shopping Cart Belongs to
        public UserInfo UserInfo { get; set; }
    }
}
