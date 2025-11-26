using Microsoft.AspNetCore.Mvc;
using MyLabApi.Services;
using MyLabApi.Models;

namespace MyLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _service;

        public ProductsController(ProductsService service)
        {
            _service = service;
        }

        [HttpGet]
    public async Task<IActionResult> GetProductsDB()
        {
            var products = await _service.GetAllProductsDB();
            return Ok(products);
        }

        [HttpGet("GetProducts")]
        public List<Products> GetProducts()
        {
            var products = _service.GetAllProducts();
            return products;
        }

        [HttpGet("GetProductById/{id:int}")]
        public Products GetProductById(int id)
        {
            var products = _service.GetProductById(id);
            return products;
        }

        [HttpPost("SaveProduct")]
        public Products SaveProduct([FromBody] Products dataProduct)
        {
            var product = _service.SaveProduct(dataProduct);
            return product;
        }

        [HttpPut("UpdateProduct/{id:int}")]
        public Products UpdateProduct([FromBody] Products dataProduct, int id)
        {
            var product = _service.UpdateProduct(dataProduct, id);
            return product;
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public void DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
        }
    }
}
