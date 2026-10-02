using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        // GET /api/tweets?userId={userId}
        [HttpGet]
        public IActionResult GetTweets([FromQuery] Guid? userId)
        {
            var tweets = _tweetService.GetTweets(userId);

            return Ok(tweets);
        }

        // GET /api/tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetService.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // POST /api/tweets
        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto request)
        {
            var tweet = _tweetService.CreateTweet(request);

            if (tweet == null)
            {
                return BadRequest("Tweet could not be created.");
            }

            return Ok(tweet);
        }

        // PUT /api/tweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTweet(
            [FromRoute] Guid id,
            [FromBody] UpdateTweetDto request)
        {
            var tweet = _tweetService.UpdateTweet(id, request);

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // DELETE /api/tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var isDeleted = _tweetService.DeleteTweet(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(isDeleted);
        }


    }
}
