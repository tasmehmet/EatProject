using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HepsiYemekApi.Business.Abstract;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Dto;
using HepsiYemekApi.WebApi.Controllers;
using HepsiYemekApi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HepsiYemekApi.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductsController _productController;

        private List<ProductModel> ProductModels = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = "1",
                Name = "Döner",
                Description = "1 porsiyon döner",
                Price = 10,
                Currency = "TL",
                Category = new CategoryModel()
                {
                    Id = "2",
                    Name = "Türk Mutfağı",
                    Description = "Türk mutfak lezzetleri"
                }
            },
            new ProductModel()
            {
                Id = "2",
                Name = "Et sote",
                Description = "1 porsiyon et",
                Price = 100,
                Currency = "TL",
                Category = new CategoryModel()
                {
                    Id = "2",
                    Name = "Türk Mutfağı",
                    Description = "Türk mutfak lezzetleri"
                }
            },            new ProductModel()
            {
                Id = "3",
                Name = "Hamburger",
                Description = "Fastfood",
                Price = 14,
                Currency = "TL",
                Category = new CategoryModel()
                {
                    Id = "2",
                    Name = "FastFood",
                    Description = "Hamburger vs"
                }
            }
            
        };
        private ProductModel ProductModel = new ProductModel()
        {
            Id = "1",
            Name = "Döner",
            Description = "1 porsiyon döner",
            Price = 10,
            Currency = "TL",
            Category = new CategoryModel()
            {
                Id = "2",
                Name = "Türk Mutfağı",
                Description = "Türk mutfak lezzetleri"
            }
        };
        private ProductDto ProductDto = new ProductDto()
        {
            Id = "1",
            Name = "Döner",
            Description = "1 porsiyon döner",
            Price = 10,
            Currency = "TL",
            CategoryId = "2"
        };
        private ProductsAddModel ProductsAddModel = new ProductsAddModel()
        {
            Name = "Döner",
            Description = "1 porsiyon döner",
            Price = 10,
            Currency = "TL",
            CategoryId = "2"
        };

        private ProductUpdateModel ProductUpdateModel = new ProductUpdateModel()
        {
            Name = "Döner",
            Description = "1 porsiyon döner",
            Price = 120,
            Currency = "TL",
            CategoryId = "2"
        };

        public ProductControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
            _mockMapper = new Mock<IMapper>();
            _productController = new ProductsController(_mockProductService.Object, _mockMapper.Object);
        }
        
        [Fact]
        public void GetProductAll_ActionExecutes_ReturnOkWithProducts()
        {
            _mockProductService.Setup(x => x.GetAllProduct()).Returns(ProductModels);

            var result = _productController.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<IEnumerable<ProductModel>>(okResult.Value);

            Assert.Equal(returnProducts,ProductModels);
        }
        
        [Fact]
        public void GetProductById_ActionExecutes_ReturnOkWithProduct()
        {
            _mockProductService.Setup(x => x.GetProductByIdAsync("1")).ReturnsAsync(ProductModel);
            
            var result = _productController.GetById("1");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnProducts = Assert.IsAssignableFrom<ProductModel>(okResult.Value);

            Assert.Equal(returnProducts,ProductModel);
        }
        
        [Fact]
        public void AddProduct_ActionExecutes_ReturnOk()
        {
            _mockProductService.Setup(x => x.AddProduct(ProductDto)).ReturnsAsync(new SuccessResponse(HttpStatusCode.OK));
            _mockMapper.Setup(x => x.Map<ProductDto>(ProductsAddModel)).Returns(ProductDto);
            
            var result = _productController.AddProduct(ProductsAddModel);

            Assert.IsType<OkObjectResult>(result.Result);
            
        }
        
        [Fact]
        public void UpdateProduct_ActionExecutes_ReturnOk()
        {
            _mockProductService.Setup(x => x.UpdateProduct("1",ProductDto)).ReturnsAsync(new SuccessResponse(HttpStatusCode.OK));
            _mockMapper.Setup(x => x.Map<ProductDto>(ProductUpdateModel)).Returns(ProductDto);
            
            var result = _productController.UpdateProduct(ProductUpdateModel,"1");

            Assert.IsType<OkObjectResult>(result.Result);
            
        }
        
        [Fact]
        public void DeleteProduct_ActionExecutes_ReturnOk()
        {
            _mockProductService.Setup(x => x.DeleteProduct("1")).ReturnsAsync(new SuccessResponse(HttpStatusCode.OK));

            var result = _productController.DeleteProduct("1");

            Assert.IsType<OkObjectResult>(result.Result);
            
        }
    }
}