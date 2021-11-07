using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Core.Caching.Redis;
using HepsiYemekApi.DataAccess.Abstract;
using HepsiYemekApi.Dto;
using HepsiYemekApi.Entitiy;
using HepsiYemekApi.Repository.Abstract;
using HepsiYemekApi.WebApi.Models;

namespace HepsiYemekApi.DataAccess.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IMapper _mapper;

        public CategoryDal(ICategoryRepository categoryRepository,IRedisCacheService redisCacheService,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _redisCacheService = redisCacheService;
            _mapper = mapper;
        }
        
        
        public IEnumerable<CategoryDto> GetAllCategory()
        {
            var data = _categoryRepository.Get();
            return _mapper.Map<IEnumerable<CategoryDto>>(data);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
            var isExists = await _redisCacheService.IsExistsAsync(id);
            if (isExists)
            {
                return await _redisCacheService.GetAsync<CategoryDto>(id);
            }

            var data = await _categoryRepository.GetByIdAsync(id);
            _redisCacheService.Set(id,data,TimeSpan.FromMinutes(5));

            return _mapper.Map<CategoryDto>(data);
        }

        public async Task<IResponse> AddCategory(CategoryDto category)
        {
            var response = await _categoryRepository.AddAsync(_mapper.Map<Category>(category));
            return response;
        }

        public async Task<IResponse> UpdateCategory(string id, CategoryDto categoryModel)
        {
            return await _categoryRepository.UpdateAsync(id,_mapper.Map<Category>(categoryModel));
        }

        public async Task<IResponse> DeleteCategory(string id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}