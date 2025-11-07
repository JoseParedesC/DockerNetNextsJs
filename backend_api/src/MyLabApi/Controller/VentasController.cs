using Microsoft.AspNetCore.Mvc;
using MyLabApi.Services;
using MyLabApi.Models;

namespace MyLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellsController : ControllerBase
    {
        private readonly SellsService _service;

        public SellsController(SellsService service)
        {
            _service = service;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetSells()
        // {
        //     var Sells = await _service.GetAllSells();
        //     return Ok(Sells);
        // }

        [HttpGet("GetSells")]
        public List<Sells> GetSells()
        {
            var Sells = _service.GetAllSells();
            return Sells;
        }

        [HttpGet("GetSellById/{id:int}")]
        public Sells GetSellById(int id)
        {
            var Sells = _service.GetSellById(id);
            return Sells;
        }

        [HttpPost("SaveSell")]
        public Sells SaveSell([FromBody] Sells dataSell)
        {
            var Sell = _service.SaveSell(dataSell);
            return Sell;
        }

        [HttpPut("UpdateSell/{id:int}")]
        public Sells UpdateSell([FromBody] Sells dataSell, int id)
        {
            var Sell = _service.UpdateSell(dataSell, id);
            return Sell;
        }

        [HttpDelete("DeleteSell/{id:int}")]
        public void DeleteSell(int id)
        {
            _service.DeleteSell(id);
        }
    }
}
