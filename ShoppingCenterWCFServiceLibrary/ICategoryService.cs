using ShoppingCenterBOL;
using System.Collections.Generic;
using System.ServiceModel;

namespace ShoppingCenterWCFServiceLibrary
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        CommonResult AddCategory(string categoryName, int parentCategoryId);

        [OperationContract]
        CommonResult RemoveCategory(int categoryId);

        [OperationContract]
        CommonResult EditCategory(Category category);

        [OperationContract]
        IEnumerable<KeyValuePair<int, string>> GetAllCategory();

        [OperationContract]
        CategoriesResult GetCategory();
    }
}
