using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCenterBOL
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public UserInfo UserInfo { get; set; }

        [EmailAddress]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public Guid ConfirmationCode { get; set; }

        public bool IsConfirmed { get; set; }

        [StringLength(1)]
        public string UserType { get; set; }
    }
}
