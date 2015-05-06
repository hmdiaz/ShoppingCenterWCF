using ShoppingCenterBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCenterWCF
{
    [DataContract(IsReference = true)]
    public class CommonResult
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }

    [DataContract]
    public class SignInResult : CommonResult
    {
        [DataMember]
        public User User { get; set; }
    }

    [DataContract]
    public class ProductsResult : CommonResult
    {
        [DataMember]
        public ICollection<Product> Products { get; set; }
    }

    [DataContract(IsReference = true)]
    public class CategoriesResult : CommonResult
    {
        [DataMember]
        public IEnumerable<Category> Categories { get; set; }
    }
}