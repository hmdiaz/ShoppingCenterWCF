using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderTime { get; set; }

        //----------------Navigation Property----------------//
        public ICollection<OrderItem> OrderItems { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
