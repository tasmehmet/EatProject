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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        
        [HttpGet("api/products/list")]
        public IActionResult Get()
        {
            var response = _productService.GetAllProduct();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        
        [HttpGet("api/products/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        
        [HttpPost()]
        public async Task<IActionResult> AddProduct([FromBody] ProductsAddModel productDto)
        {
            var response = await _productService.AddProduct(_mapper.Map<ProductDto>(productDto));
            return this.GetResponse(response);
        }
        
        [HttpPut("api/products/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateModel product,string id)
        {
            var response = await _productService.UpdateProduct(id,_mapper.Map<ProductDto>(product));
            return this.GetResponse(response);
        }
        
        [HttpDelete("api/products/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var response = await _productService.DeleteProduct(id);
            return this.GetResponse(response);
        }
    }
}