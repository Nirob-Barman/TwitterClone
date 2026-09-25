using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        // POST: api/messages
        [HttpPost]
        public IActionResult SendMessage()
        {
            return Ok(new
            {
                message = "Message sent successfully."
            });
        }

        // GET: api/messages/conversations
        [HttpGet("conversations")]
        public IActionResult GetConversations()
        {
            return Ok();
        }

        // GET: api/messages/conversations/{conversationId}
        [HttpGet("conversations/{conversationId}")]
        public IActionResult GetConversation(int conversationId)
        {
            return Ok();
        }

        // POST: api/messages/conversations/{conversationId}
        [HttpPost("conversations/{conversationId}")]
        public IActionResult SendMessageToConversation(int conversationId)
        {
            return Ok(new
            {
                message = "Message sent successfully."
            });
        }

        // DELETE: api/messages/{messageId}
        [HttpDelete("{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            return Ok(new
            {
                message = "Message deleted successfully."
            });
        }

        // PATCH: api/messages/{messageId}/read
        [HttpPatch("{messageId}/read")]
        public IActionResult MarkAsRead(int messageId)
        {
            return Ok(new
            {
                message = "Message marked as read."
            });
        }
    }
}
