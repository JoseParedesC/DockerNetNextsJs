using Microsoft.AspNetCore.Mvc;
using MyLabApi.Services;
using MyLabApi.Models;

namespace MyLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly VentasService _service;

        public VentasController(VentasService service)
        {
            _service = service;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetVentas()
        // {
        //     var Ventas = await _service.GetAllVentas();
        //     return Ok(Ventas);
        // }

        [HttpGet("GetVentas")]
        public List<Ventas> GetVentas()
        {
            var ventas = _service.GetAllVentas();
            return ventas;
        }

        [HttpGet("GetSellById/{id:int}")]
        public Ventas GetSellById(int id)
        {
            var ventas = _service.GetSellById(id);
            return ventas;
        }

        [HttpGet("ventas_details/{id:int}")]
        public Ventas ventas_details(int id)
        {
            var ventas = _service.GetSellById(id);
            return ventas;
        }

        [HttpPost("SaveSell")]
        public Ventas SaveSell([FromBody] Ventas dataSell)
        {
            var Sell = _service.SaveSell(dataSell);
            return Sell;
        }

        [HttpPut("UpdateSell/{id:int}")]
        public Ventas UpdateSell([FromBody] Ventas dataSell, int id)
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
