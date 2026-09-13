using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new { Id = 1, Name = "Bill Gates", Handle = "@billgates" },
                new { Id = 2, Name = "Elon Musk", Handle = "@elonmusk" },
                new { Id = 3, Name = "Mark Zuckerberg", Handle = "@zuck" },
                new { Id = 4, Name = "Larry Page", Handle = "@larrypage" },
                new { Id = 5, Name = "Sundar Pichai", Handle = "@sundarpichai" },
            };

            return Ok(users);
        }
    }
}
