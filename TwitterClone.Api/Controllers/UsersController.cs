using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // /api/users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            return Ok(users);
        }

        // /api/users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto request)
        {
            var user = _userService.CreateUser(request);

            if(user == null)
            {
                return BadRequest("User could not be created.");
            }

            return Ok(user);
        }


        // /api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // PUT /api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserDto request)
        {
            var user = _userService.UpdateUser(id, request);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // PATCH /api/users/{id}/phoneNumber
        [HttpPatch("{id}/phoneNumber")]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody] string phoneNumber)
        {
            return Ok("hello");

        }

        // DELETE /api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var isDeleted = _userService.DeleteUser(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(isDeleted);
        }
    }
}
