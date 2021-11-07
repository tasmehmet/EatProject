using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using HepsiYemekApi.Business.Abstract;
using HepsiYemekApi.Common.Extensions;
using HepsiYemekApi.Dto;
using HepsiYemekApi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HepsiYemekApi.WebApi.Controllers
{
    [
        ApiController,
        Route("api/[controller]"),
        Produces(MediaTypeNames.Application.Json)
    ]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        [HttpGet("api/category/list")]
        public IActionResult Get()
        {
            var response = _categoryService.GetAllCategory();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        
        [HttpGet("api/category/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        
        [HttpPost()]
        public async Task<IActionResult> AddCategory([FromBody] CategoryAddModel category)
        {
            var response = await _categoryService.AddCategory(_mapper.Map<CategoryDto>(category));
            return this.GetResponse(response);
        }
        
        [HttpPut("api/category/{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel product,string id)
        {
            var response = await _categoryService.UpdateCategory(id,_mapper.Map<CategoryDto>(product));
            return this.GetResponse(response);
        }
        
        [HttpDelete("api/category/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return this.GetResponse(response);
        }
    }
}