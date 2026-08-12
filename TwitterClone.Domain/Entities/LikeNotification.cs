
namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {

        public LikeNotification(Guid likeByUserId) : base("Like")
        {
            LikeByUserId = likeByUserId;
        }

        public Guid LikeByUserId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }
    }
}
