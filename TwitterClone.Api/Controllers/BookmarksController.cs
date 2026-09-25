using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        // POST: api/bookmarks/{tweetId}
        [HttpPost("{tweetId}")]
        public IActionResult AddBookmark(int tweetId)
        {
            return Ok(new { message = "Tweet bookmarked successfully." });
        }

        // DELETE: api/bookmarks/{tweetId}
        [HttpDelete("{tweetId}")]
        public IActionResult RemoveBookmark(int tweetId)
        {
            return Ok(new { message = "Bookmark removed successfully." });
        }

        // GET: api/bookmarks
        [HttpGet]
        public IActionResult GetBookmarks()
        {
            return Ok();
        }

        // GET: api/bookmarks/{tweetId}
        [HttpGet("{tweetId}")]
        public IActionResult CheckBookmark(int tweetId)
        {
            return Ok();
        }

        // DELETE: api/bookmarks
        [HttpDelete]
        public IActionResult RemoveAllBookmarks()
        {
            return Ok(new { message = "All bookmarks removed successfully." });
        }
    }
}
