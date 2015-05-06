using ShoppingCenterBOL;
using ShoppingCenterDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCF
{
    public class ProductManageService : IProductManageService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ProductsResult GetProductsByCategory(int categoryId, int productCount)
        {
            throw new NotImplementedException();
        }

        public CommonResult AddProduct(ShoppingCenterBOL.Product product)
        {
            try
            {
                unitOfWork.ProductRepository.Insert(product);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
            return new CommonResult() { Success = true };
        }

        public CommonResult RemoveProduct(ShoppingCenterBOL.Product product)
        {
            try
            {
                unitOfWork.ProductRepository.Delete(product);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
            return new CommonResult() { Success = true };
        }

        public CommonResult EditProduct(ShoppingCenterBOL.Product product)
        {
            try
            {
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
            return new CommonResult() { Success = true };
        }


        public CommonResult AddCategory(string categoryName, int parentCategoryId)
        {
            Category category = new Category()
            {
                CategoryName = categoryName,
                Parent = null,
                //Children = null,
                Products = null,
            };

            //判断parentCategoryId是否存在
            if (parentCategoryId > 0)
            {
                //ParentId >0 有可能存在
                //ParentId 是否有对应 Category
                var parentCategory = unitOfWork.CategoryRepository.GetById(parentCategoryId);

                if (parentCategory != null)
                {
                    //Parent Category 存在
                    category.Parent = parentCategory;
                }
            }
            return AddCategory(category);
        }

        private CommonResult AddCategory(ShoppingCenterBOL.Category category)
        {
            try
            {
                unitOfWork.CategoryRepository.Insert(category);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
            return new CommonResult() { Success = true };
        }

        public CommonResult RemoveCategory(ShoppingCenterBOL.Category category)
        {
            try
            {
                unitOfWork.CategoryRepository.Delete(category);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
            return new CommonResult() { Success = true };
        }

        public CommonResult EditCategory(ShoppingCenterBOL.Category category)
        {
            try
            {
                unitOfWork.CategoryRepository.Update(category);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
            return new CommonResult() { Success = true };
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllCategory()
        {
            return unitOfWork.CategoryRepository.Get(null, e => e.OrderBy(f => f.CategoryId)).Select(e => new KeyValuePair<int, string>(e.CategoryId, e.CategoryName));
        }

        public CategoriesResult GetCategory()
        {
            try
            {
                var list = unitOfWork.CategoryRepository.Get();
                return new CategoriesResult() { Success = true, Categories = list };
            }
            catch(Exception ee)
            {
                return new CategoriesResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
        }
    }
}
