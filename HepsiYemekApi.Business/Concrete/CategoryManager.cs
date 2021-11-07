using System.Collections.Generic;
using System.Threading.Tasks;
using HepsiYemekApi.Business.Abstract;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.DataAccess.Abstract;
using HepsiYemekApi.Dto;

namespace HepsiYemekApi.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        
        public IEnumerable<CategoryDto> GetAllCategory()
        {
            return _categoryDal.GetAllCategory();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
            return await _categoryDal.GetCategoryByIdAsync(id);
        }

        public async Task<IResponse> AddCategory(CategoryDto category)
        {
            return await _categoryDal.AddCategory(category);
        }

        public async Task<IResponse> UpdateCategory(string id,CategoryDto categoryDto)
        {
            return await _categoryDal.UpdateCategory(id,categoryDto);
        }

        public async Task<IResponse> DeleteCategory(string id)
        {
            return await _categoryDal.DeleteCategory(id);
        }
    }
}