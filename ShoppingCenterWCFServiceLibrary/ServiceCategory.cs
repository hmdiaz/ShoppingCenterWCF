using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL;
using ShoppingCenterWCFServiceLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCFServiceLibrary
{
    public class ServiceCategory : IServiceCategory
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
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException == null ? "" : ee.InnerException.Message };
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
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException == null ? "" : ee.InnerException.Message };
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
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException == null ? "" : ee.InnerException.Message };
            }
        }

        public CategoriesResult GetAllCategory()
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
                return new CategoriesResult() { Success = true, Categories = DTOCategories };
            }
            catch (Exception ee)
            {
                return new CategoriesResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException == null ? "" : ee.InnerException.Message };
            }
        }
    }
}
