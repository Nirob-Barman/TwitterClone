using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // GET: api/notifications
        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok();
        }

        // GET: api/notifications/unread
        [HttpGet("unread")]
        public IActionResult GetUnreadNotifications()
        {
            return Ok();
        }

        // GET: api/notifications/unread/count
        [HttpGet("unread/count")]
        public IActionResult GetUnreadCount()
        {
            return Ok();
        }

        // PATCH: api/notifications/{notificationId}/read
        [HttpPatch("{notificationId}/read")]
        public IActionResult MarkAsRead(int notificationId)
        {
            return Ok(new
            {
                message = "Notification marked as read."
            });
        }

        // PATCH: api/notifications/read-all
        [HttpPatch("read-all")]
        public IActionResult MarkAllAsRead()
        {
            return Ok(new
            {
                message = "All notifications marked as read."
            });
        }

        // DELETE: api/notifications/{notificationId}
        [HttpDelete("{notificationId}")]
        public IActionResult DeleteNotification(int notificationId)
        {
            return Ok(new
            {
                message = "Notification deleted successfully."
            });
        }

        // DELETE: api/notifications
        [HttpDelete]
        public IActionResult DeleteAllNotifications()
        {
            return Ok(new
            {
                message = "All notifications deleted successfully."
            });
        }
    }
}
