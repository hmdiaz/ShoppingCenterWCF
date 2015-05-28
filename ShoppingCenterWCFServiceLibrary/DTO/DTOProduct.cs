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
    public class DTOProduct
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductDescription { get; set; }

        [DataMember]
        public int ProviderId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        public DTOProduct(Product product)
        {
            this.ProductId = product.ProductId;
            this.ProductName = product.ProductName;
            this.ProductDescription = product.ProductDescription;
            this.ProviderId = product.Provider.ProviderId;
            this.CategoryId = product.Category.CategoryId;
        }
    }
}
