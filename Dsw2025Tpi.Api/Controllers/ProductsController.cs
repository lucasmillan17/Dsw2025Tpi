using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dsw2025Tpi.Application.Exceptions;
using System;
using System.Threading.Tasks;
namespace Dsw2025Tpi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModelRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var product = await _productService.CreateProductAsync(request);
                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
            }
            catch (DuplicatedItemException ex) { 
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (NotFoundException ex) {
                return NotFound(ex.Message);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            if (products == null || !products.Any())
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> DisableProductById(Guid id)
        {
            try
            {
                await _productService.DisableProductById(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id,[FromBody] ProductModelUpdateRequest request)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductsAsync(id, request);
                return Ok(updatedProduct);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicatedItemException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}