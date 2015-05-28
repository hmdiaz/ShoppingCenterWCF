using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL;
using ShoppingCenterWCFServiceLibrary.DTO;
using ShoppingCenterWCFServiceLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCFServiceLibrary
{
    public class ServiceProduct : IServiceProduct
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CommonResult AddCategory(string categoryName, int parentCategoryId)
        {
            try
            {
                Category parentCategory;

                //Check if New Category has a parent
                if (parentCategoryId == 0)
                {
                    //No parent
                    parentCategory = null;
                }
                else
                {
                    //Get Parent Category
                    parentCategory = unitOfWork.CategoryRepository.GetById(parentCategoryId);
                }

                //insert category to context
                unitOfWork.CategoryRepository.Insert(new Category() { CategoryName = categoryName, Parent = parentCategory });

                //save
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult RemoveCategory(int categoryId)
        {
            try
            {
                //remove category
                unitOfWork.CategoryRepository.Delete(categoryId);

                //save
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult EditCategory(int categoryId, string categoryName, int parentCategoryId)
        {
            try
            {
                Category parentCategory;

                //Check if New Category has a parent
                if (parentCategoryId == 0)
                {
                    //No parent
                    parentCategory = null;
                }
                else
                {
                    //Get Parent Category
                    parentCategory = unitOfWork.CategoryRepository.GetById(parentCategoryId);
                }

                //Edit category
                unitOfWork.CategoryRepository.Update(new Category() { CategoryId = categoryId, CategoryName = categoryName, Parent = parentCategory });

                //save
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CategoryResult GetAllCategory()
        {
            try
            {
                //Get All Categories from Database
                var categories = unitOfWork.CategoryRepository.Get(null, null, "Parent");

                //Create List of DTO Category
                List<DTOCategory> DTOCategories = new List<DTOCategory>();

                //Fill the list
                foreach (var category in categories)
                {
                    DTOCategories.Add(new DTOCategory(category));
                }

                //return the result
                return new CategoryResult() { Success = true, Categories = DTOCategories };
            }
            catch (Exception ee)
            {
                return new CategoryResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }


        public CommonResult AddProvider(string providerName)
        {
            try
            {
                //Add Provider To Database
                unitOfWork.ProviderRepository.Insert(new Provider() { ProviderName = providerName });
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult RemoveProvider(int providerId)
        {
            try
            {
                //Remove Provider From Database
                unitOfWork.ProviderRepository.Delete(providerId);
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult EditProvider(int providerId, string providerName)
        {
            try
            {
                //Edit Provider In Database
                unitOfWork.ProviderRepository.Update(new Provider() { ProviderId = providerId, ProviderName = providerName });
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public ProviderResult GetProviderById(int providerId)
        {
            try
            {
                //Edit Provider In Database
                var provider = unitOfWork.ProviderRepository.GetById(providerId);

                //Check Provider
                if (provider != null)
                {
                    //Provider exists
                    return new ProviderResult() { Success = true, Provider = new DTOProvider(provider) };
                }
                else
                {
                    //Provider does not exist
                    return new ProviderResult() { Success = false, ErrorMessage = "Provider does not exist" };
                }
            }
            catch (Exception ee)
            {
                return new ProviderResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult AddProduct(string productName, string productDesc, int providerId, int categoryId)
        {
            try
            {
                //Get Provider
                Provider provider = unitOfWork.ProviderRepository.GetById(providerId);

                //Check Provider
                if (provider == null)
                {
                    return new CommonResult() { Success = false, ErrorMessage = "Provider does not exists" };
                }

                //Get Category
                Category category = unitOfWork.CategoryRepository.GetById(categoryId);

                //Check Category
                if (category == null)
                {
                    return new CommonResult() { Success = false, ErrorMessage = "Category does not exists" };
                }

                unitOfWork.ProductRepository.Insert(new Product() { ProductName = productName, ProductDescription = productDesc, Provider = provider, Category = category });
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult RemoveProduct(int productId)
        {
            try
            {
                unitOfWork.ProductRepository.Delete(productId);
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        public CommonResult EditProduct(string productName, string productDesc, int providerId, int categoryId)
        {
            try
            {
                //Get Provider
                Provider provider = unitOfWork.ProviderRepository.GetById(providerId);

                //Check Provider
                if (provider == null)
                {
                    return new CommonResult() { Success = false, ErrorMessage = "Provider does not exists" };
                }

                //Get Category
                Category category = unitOfWork.CategoryRepository.GetById(categoryId);

                //Check Category
                if (category == null)
                {
                    return new CommonResult() { Success = false, ErrorMessage = "Category does not exists" };
                }

                unitOfWork.ProductRepository.Insert(new Product() { ProductName = productName, ProductDescription = productDesc, Provider = provider, Category = category });
                unitOfWork.Save();

                return new CommonResult() { Success = true };
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }
        }

        ProductResult IServiceProduct.GetProviderById(int providerId)
        {
            throw new NotImplementedException();
        }
    }
}
