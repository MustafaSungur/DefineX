using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly string[] value = ["Ayakkabı", "Kulaklık", "Bilgisayar"];

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new { products = value });
        }
    }
}
