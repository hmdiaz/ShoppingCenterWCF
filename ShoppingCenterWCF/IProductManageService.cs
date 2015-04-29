using ShoppingCenterBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCF
{
    [ServiceContract]
    public interface IProductManageService
    {
        [OperationContract]
        ProductsResult GetProductsByCategory(int categoryId, int productCount);

        [OperationContract]
        CommonResult AddProduct(Product product);

        [OperationContract]
        CommonResult RemoveProduct(Product product);

        [OperationContract]
        CommonResult EditProduct(Product product);

        [OperationContract]
        CommonResult AddCategory(Category category);

        [OperationContract]
        CommonResult RemoveCategory(Category category);

        [OperationContract]
        CommonResult EditCategory(Category category);

        [OperationContract]
        IEnumerable<Category> GetAllCategory();
    }
}
