using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        // POST: api/follows/{userId}
        [HttpPost("{userId}")]
        public IActionResult FollowUser(int userId)
        {
            return Ok(new
            {
                message = "User followed successfully."
            });
        }

        // DELETE: api/follows/{userId}
        [HttpDelete("{userId}")]
        public IActionResult UnfollowUser(int userId)
        {
            return Ok(new
            {
                message = "User unfollowed successfully."
            });
        }

        // GET: api/follows/followers/{userId}
        [HttpGet("followers/{userId}")]
        public IActionResult GetFollowers(int userId)
        {
            return Ok();
        }

        // GET: api/follows/following/{userId}
        [HttpGet("following/{userId}")]
        public IActionResult GetFollowing(int userId)
        {
            return Ok();
        }

        // GET: api/follows/{userId}/status
        [HttpGet("{userId}/status")]
        public IActionResult GetFollowStatus(int userId)
        {
            return Ok();
        }

        // GET: api/follows/{userId}/followers/count
        [HttpGet("{userId}/followers/count")]
        public IActionResult GetFollowersCount(int userId)
        {
            return Ok();
        }

        // GET: api/follows/{userId}/following/count
        [HttpGet("{userId}/following/count")]
        public IActionResult GetFollowingCount(int userId)
        {
            return Ok();
        }
    }
}
