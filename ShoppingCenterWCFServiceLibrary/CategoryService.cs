using ShoppingCenterDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCenterWCFServiceLibrary
{
    public class CategoryService : ICategoryService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CommonResult AddCategory(string categoryName, int parentCategoryId)
        {
            throw new NotImplementedException();
        }

        public CommonResult RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public CommonResult EditCategory(ShoppingCenterBOL.Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllCategory()
        {
            try
            {
                return unitOfWork.CategoryRepository.Get(null, e => e.OrderBy(f => f.CategoryId)).Select(e => new KeyValuePair<int, string>(e.CategoryId, e.CategoryName));
            }
            catch(Exception ee)
            {
                throw;
            }
        }

        public CategoriesResult GetCategory()
        {
            try
            {
                var list = unitOfWork.CategoryRepository.Get();
                return new CategoriesResult() { Success = true, Categories = list };
            }
            catch (Exception ee)
            {
                return new CategoriesResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
            }
        }
    }
}
