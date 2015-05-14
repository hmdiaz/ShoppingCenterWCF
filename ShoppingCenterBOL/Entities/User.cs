using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCenterBOL.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [EmailAddress]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public Guid ConfirmationCode { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime? LastErrorDateTime { get; set; }

        public int ErrorTimes { get; set; }

        [StringLength(1)]
        public string UserType { get; set; }

        public DateTime RegisteredDate { get; set; }

        //----------------Navigation Property----------------//
        public UserInfo UserInfo { get; set; }

    }
}
