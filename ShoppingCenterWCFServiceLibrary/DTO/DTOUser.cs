using ShoppingCenterBOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterWCFServiceLibrary.DTO
{
    [DataContract]
    public class DTOUser
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string UserName { get; set; }

        public DTOUser(User user)
        {
            this.UserId = user.UserId;
            this.Email = user.Email;
            this.UserName = user.UserName;
        }
    }
}
