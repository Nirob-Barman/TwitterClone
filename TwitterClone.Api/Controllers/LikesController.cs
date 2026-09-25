using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        // POST: api/likes/{tweetId}
        [HttpPost("{tweetId}")]
        public IActionResult LikeTweet(int tweetId)
        {
            return Ok(new
            {
                message = "Tweet liked successfully."
            });
        }

        // DELETE: api/likes/{tweetId}
        [HttpDelete("{tweetId}")]
        public IActionResult UnlikeTweet(int tweetId)
        {
            return Ok(new
            {
                message = "Tweet unliked successfully."
            });
        }

        // GET: api/likes/{tweetId}/status
        [HttpGet("{tweetId}/status")]
        public IActionResult GetLikeStatus(int tweetId)
        {
            return Ok();
        }

        // GET: api/likes/{tweetId}/count
        [HttpGet("{tweetId}/count")]
        public IActionResult GetLikeCount(int tweetId)
        {
            return Ok();
        }

        // GET: api/likes/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetLikedTweets(int userId)
        {
            return Ok();
        }
    }
}
