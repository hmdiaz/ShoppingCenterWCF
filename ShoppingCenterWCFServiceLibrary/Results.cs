using ShoppingCenterBOL.Entities;
using ShoppingCenterWCFServiceLibrary.DTO;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShoppingCenterWCFServiceLibrary
{
    [DataContract(IsReference = true)]
    public class CommonResult
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }

    //Sign In Result
    [DataContract]
    public class SignInResult : CommonResult
    {
        [DataMember]
        public DTOUser User { get; set; }
    }

    //Category Results
    [DataContract]
    public class CategoriesResult : CommonResult
    {
        [DataMember]
        public IEnumerable<DTOCategory> Categories { get; set; }
    }
}