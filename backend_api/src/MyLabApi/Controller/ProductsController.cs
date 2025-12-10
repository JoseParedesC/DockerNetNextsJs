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

        #region DATABASE
        [HttpGet]
        public async Task<IActionResult> GetProductsDB()
        {
            var products = await _service.GetAllProductsDB();
            return Ok(products);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdDB(id);
            return Ok(products);
        }

        [HttpPost("SaveProductDB")]
        public async Task<IActionResult> SaveProductDB([FromBody] Products dataProduct)
        {
            var product = await _service.SaveProductDB(dataProduct);
            return Ok(product);
        }

        [HttpPut("UpdateProductDB/{id:int}")]
        public async Task<IActionResult> UpdateProductDB([FromBody] Products dataProduct, int id)
        {
            var product = await _service.UpdateProductDB(dataProduct, id);
            return Ok(product);
        }

        [HttpDelete("DeleteProductDB/{id:int}")]
        public async Task<IActionResult> DeleteProductDB(int id)
        {
            return Ok(await _service.DeleteProductDB(id));
        }

        #endregion DATABASE

        #region LIST

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

        #endregion LIST
    }
}
