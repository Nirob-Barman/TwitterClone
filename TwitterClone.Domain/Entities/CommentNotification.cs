
namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        public CommentNotification(Guid commentByUserId) : base("Comment")
        {
            CommentByUserId = commentByUserId;
        }

        public Guid CommentByUserId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }
    }
}
