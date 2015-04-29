using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
