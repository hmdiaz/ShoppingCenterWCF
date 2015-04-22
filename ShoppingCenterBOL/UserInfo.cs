using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCenterBOL
{
    public class UserInfo
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        public DateTime SignInDateTime { get; set; }
    }
}
