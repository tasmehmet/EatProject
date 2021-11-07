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
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryService> _mockCategoryService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CategoryController _categoryController;

        private List<CategoryDto> CategoryModels = new List<CategoryDto>()
        {
            new CategoryDto()
                {
                    Id = "1",
                    Name = "Türk Mutfağı",
                    Description = "Türk mutfak lezzetleri"
                },
            new CategoryDto()
                {
                    Id = "3",
                    Name = "Amerika Mutfağı",
                    Description = "Amerika mutfak lezzetleri"
                },
            new CategoryDto()
                {
                    Id = "2",
                    Name = "FastFood",
                    Description = "Hamburger vs"
                }
        };
        private CategoryModel CategoryModel = new CategoryModel()
        {
            Id = "1",
                Name = "Türk Mutfağı",
                Description = "Türk mutfak lezzetleri"
        };
        private CategoryDto CategoryDto = new CategoryDto()
        {
            Id = "1",
            Name = "Türk Mutfağı",
            Description = "Türk mutfak lezzetleri"
        };
        private CategoryAddModel CategoryAddModel = new CategoryAddModel()
        {
            Name = "Türk Mutfağı",
            Description = "Türk mutfak lezzetleri"
        };

        public CategoryControllerTest()
        {
            _mockCategoryService = new Mock<ICategoryService>();
            _mockMapper = new Mock<IMapper>();
            _categoryController = new CategoryController(_mockCategoryService.Object, _mockMapper.Object);
        }
        
        [Fact]
        public void GetCategoryAll_ActionExecutes_ReturnOkWithCategory()
        {
            _mockCategoryService.Setup(x => x.GetAllCategory()).Returns(CategoryModels);

            var result = _categoryController.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<IEnumerable<CategoryDto>>(okResult.Value);

            Assert.Equal(returnProducts.ToList(), CategoryModels);
        }
        
        [Fact]
        public void GetCategoryById_ActionExecutes_ReturnOkWithCategory()
        {
            _mockCategoryService.Setup(x => x.GetCategoryByIdAsync("1")).ReturnsAsync(CategoryDto);

            var result = _categoryController.GetById("1");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnProducts = Assert.IsAssignableFrom<CategoryDto>(okResult.Value);

            Assert.Equal(returnProducts,CategoryDto);
        }
        
        [Fact]
        public void AddCategory_ActionExecutes_ReturnOk()
        {
            _mockCategoryService.Setup(x => x.AddCategory(CategoryDto)).ReturnsAsync(new SuccessResponse(HttpStatusCode.OK));
            _mockMapper.Setup(x => x.Map<CategoryDto>(CategoryAddModel)).Returns(CategoryDto);
            
            var result = _categoryController.AddCategory(CategoryAddModel);

            Assert.IsType<OkObjectResult>(result.Result);
            
        }
        
        [Fact]
        public void UpdateCategory_ActionExecutes_ReturnOk()
        {
            _mockCategoryService.Setup(x => x.UpdateCategory("1",CategoryDto)).ReturnsAsync(new SuccessResponse(HttpStatusCode.OK));
            _mockMapper.Setup(x => x.Map<CategoryDto>(CategoryModel)).Returns(CategoryDto);
            
            var result = _categoryController.UpdateCategory(CategoryModel,"1");

            Assert.IsType<OkObjectResult>(result.Result);
            
        }
        
        [Fact]
        public void DeleteCategory_ActionExecutes_ReturnOk()
        {
            _mockCategoryService.Setup(x => x.DeleteCategory("1")).ReturnsAsync(new SuccessResponse(HttpStatusCode.OK));

            var result = _categoryController.DeleteCategory("1");

            Assert.IsType<OkObjectResult>(result.Result);
            
        }
    }
}