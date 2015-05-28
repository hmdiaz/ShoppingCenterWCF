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
    public interface IServiceProduct
    {
        #region Category Services
        //Category Add
        [OperationContract]
        CommonResult AddCategory(string categoryName, int parentCategoryId);

        //Category Remove
        [OperationContract]
        CommonResult RemoveCategory(int categoryId);

        //Category Edit
        [OperationContract]
        CommonResult EditCategory(int categoryId, string categoryName, int parentCategoryId);

        //Category Get All
        [OperationContract]
        CategoryResult GetAllCategory();
        #endregion

        #region Provider Services
        //Provider Add
        [OperationContract]
        CommonResult AddProvider(string providerName);

        //Provider Remove
        [OperationContract]
        CommonResult RemoveProvider(int providerId);

        //Provider Edit
        [OperationContract]
        CommonResult EditProvider(int providerId, string providerName);

        //Get Provider By PrividerId
        [OperationContract]
        ProviderResult GetProviderById(int providerId);
        #endregion

        #region Product Service
        //Product Add
        [OperationContract]
        CommonResult AddProduct(string productName, string productDesc, int providerId, int categoryId);

        //Product Remove
        [OperationContract]
        CommonResult RemoveProduct(int productId);

        //Product Edit
        [OperationContract]
        CommonResult EditProduct(string productName, string productDesc, int providerId, int categoryId);

        //Get Product By Id
        [OperationContract]
        ProductResult GetProviderById(int providerId);
        #endregion
    }
}
