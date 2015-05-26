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
    public class DTOCategory
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int ParentCategoryId { get; set; }

        public DTOCategory(Category category)
        {
            this.CategoryId = category.CategoryId;
            this.CategoryName = category.CategoryName;
            this.ParentCategoryId = category.Parent == null ? 0 : category.Parent.CategoryId; 
        }
    }
}
