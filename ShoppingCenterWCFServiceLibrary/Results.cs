using ShoppingCenterBOL;
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

    //
    [DataContract]
    public class SignInResult : CommonResult
    {
        [DataMember]
        public User User { get; set; }
    }

    //
    [DataContract]
    public class ProductsResult : CommonResult
    {
        [DataMember]
        public ICollection<Product> Products { get; set; }
    }

    //Category Results
    [DataContract(IsReference = true)]
    public class CategoriesResult : CommonResult
    {
        [DataMember]
        public IEnumerable<Category> Categories { get; set; }
    }
}