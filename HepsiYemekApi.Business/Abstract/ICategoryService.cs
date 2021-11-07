using System.Collections.Generic;
using System.Threading.Tasks;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Dto;

namespace HepsiYemekApi.Business.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategory();
        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task<IResponse> AddCategory(CategoryDto category);
        Task<IResponse> UpdateCategory(string id, CategoryDto categoryDto);
        Task<IResponse> DeleteCategory(string id);
    }
}