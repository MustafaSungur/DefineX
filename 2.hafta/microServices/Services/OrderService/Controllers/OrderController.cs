using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static readonly string[] value = ["Sipariş-1", "Sipariş-2", "Sipariş-3"];

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(new { orders = value });
        }
    }
}
