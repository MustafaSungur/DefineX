using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string[] value = ["User1", "User2", "User3"];

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(new { users = value });
        }
    }
}
