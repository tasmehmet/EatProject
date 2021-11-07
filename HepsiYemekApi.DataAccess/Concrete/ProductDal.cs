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

namespace HepsiYemekApi.DataAccess.Concrete
{
    public class ProductDal : IProductDal
    {
        private readonly IProductRepository _productRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IMapper _mapper;

        public ProductDal(IProductRepository productRepository,IRedisCacheService redisCacheService,IMapper mapper)
        {
            _productRepository = productRepository;
            _redisCacheService = redisCacheService;
            _mapper = mapper;
        }
        
        
        public IEnumerable<ProductDto> GetAllProduct()
        {
            var data = _productRepository.Get();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var isExists = await _redisCacheService.IsExistsAsync(id);
            if (isExists)
            {
                return await _redisCacheService.GetAsync<ProductDto>(id);
            }

            var data = await _productRepository.GetByIdAsync(id);
            _redisCacheService.Set(id,data,TimeSpan.FromMinutes(5));

            return _mapper.Map<ProductDto>(data);
        }

        public async Task<IResponse> AddProduct(ProductDto category)
        {
            return await _productRepository.AddAsync(_mapper.Map<Product>(category));
        }

        public async Task<IResponse> UpdateProduct(string id, ProductDto product)
        {
            return await _productRepository.UpdateAsync(id,_mapper.Map<Product>(product));
        }

        public async Task<IResponse> DeleteProduct(string id)
        {
            return await _productRepository.DeleteAsync(id);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}