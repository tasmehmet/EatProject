using System.Collections.Generic;
using System.Threading.Tasks;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Dto;
using HepsiYemekApi.WebApi.Models;

namespace HepsiYemekApi.Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProduct();
        Task<ProductModel> GetProductByIdAsync(string id);
        Task<IResponse> AddProduct(ProductDto product);
        Task<IResponse> UpdateProduct(string id,ProductDto product);
        Task<IResponse> DeleteProduct(string id);
    }
}