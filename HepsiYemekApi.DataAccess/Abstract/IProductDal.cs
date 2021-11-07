using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Dto;

namespace HepsiYemekApi.DataAccess.Abstract
{
    public interface IProductDal: IDisposable
    {
        IEnumerable<ProductDto> GetAllProduct();
        Task<ProductDto> GetProductByIdAsync(string id);
        Task<IResponse> AddProduct(ProductDto product);
        Task<IResponse> UpdateProduct(string id, ProductDto product);
        Task<IResponse> DeleteProduct(string id);
    }
}