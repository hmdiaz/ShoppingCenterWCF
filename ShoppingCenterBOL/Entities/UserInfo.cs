using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCenterBOL.Entities
{
    public class UserInfo
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        //----------------Navigation Property----------------//
        public User User { get; set; }

        //User's Shopping Cart
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
