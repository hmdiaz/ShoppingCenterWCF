using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL
{
    [DataContract(IsReference = true)]
    public class Category
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public Category Parent { get; set; }

        [DataMember]
        public ICollection<Category> Children { get; set; }

        [DataMember]
        public ICollection<Product> Products { get; set; }
    }
}
