using ShoppingCenterBOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCFServiceLibrary
{
    [ServiceContract]
    public interface IServiceCategory
    {
        [OperationContract]
        CommonResult AddCategory(string categoryName, int parentCategoryId);

        [OperationContract]
        CommonResult RemoveCategory(int categoryId);

        [OperationContract]
        CommonResult EditCategory(int categoryId, string categoryName, int parentCategoryId);

        [OperationContract]
        CategoriesResult GetAllCategory();
    }
}
