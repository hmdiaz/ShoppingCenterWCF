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

        public CommonResult AddCategory(ShoppingCenterBOL.Category category)
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

        public IEnumerable<ShoppingCenterBOL.Category> GetAllCategory()
        {
            return unitOfWork.CategoryRepository.Get(null, e => e.OrderBy(f => f.CategoryId));
        }
    }
}
