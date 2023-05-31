using Microsoft.AspNetCore.Mvc;
using ProductManager.Dtos.Product;
using ProductManager.Services.Interfaces;

namespace ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll([FromQuery] ProductFilterDto input)
        {
            return Ok(_productService.GetProducts(input));
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _productService.GetProductById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create-new-product")]
        public IActionResult Create(CreateProductDto input)
        {
            try
            {
                var result = _productService.CreateProduct(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(UpdateProductDto input)
        {
            try
            {
                var result = _productService.UpdateProduct(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _productService.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
