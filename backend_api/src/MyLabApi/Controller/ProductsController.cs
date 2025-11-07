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
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }
    }
}
