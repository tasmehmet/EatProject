using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HepsiYemekApi.Business.Abstract;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.DataAccess.Abstract;
using HepsiYemekApi.Dto;
using HepsiYemekApi.WebApi.Models;

namespace HepsiYemekApi.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal,ICategoryDal categoryDal,IMapper mapper)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        
        public IEnumerable<ProductModel> GetAllProduct()
        {
            var product =_productDal.GetAllProduct();
            var categories = _categoryDal.GetAllCategory();
            var productModel = product.Select(t => new ProductModel()
            {
                Id = t.Id,
                Category = _mapper.Map<CategoryModel>(categories?.FirstOrDefault(c=>c.Id == t.CategoryId)),
                Name = t.Name,
                Currency = t.Currency,
                Description = t.Description,
                Price = t.Price
            });
            return productModel;
        }

        public async Task<ProductModel> GetProductByIdAsync(string id)
        {
            var product = await _productDal.GetProductByIdAsync(id);
            var categories = _categoryDal.GetAllCategory();
            var productModel =new ProductModel()
            {
                Id = product.Id,
                Category = _mapper.Map<CategoryModel>(categories?.FirstOrDefault(c=>c.Id == product.CategoryId)),
                Name = product.Name,
                Currency = product.Currency,
                Description = product.Description,
                Price = product.Price
            };
            return productModel;
        }

        public Task<IResponse> AddProduct(ProductDto product)
        {
            return _productDal.AddProduct(product);
        }

        public Task<IResponse> UpdateProduct(string id,ProductDto product)
        {
            return _productDal.UpdateProduct(id,product);
        }

        public Task<IResponse> DeleteProduct(string id)
        {
            return _productDal.DeleteProduct(id);
        }
    }
}