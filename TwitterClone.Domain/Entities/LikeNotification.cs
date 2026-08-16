
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

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"BaseRecord: {baseRecord} - Notification Type: {Type}, Message: {Message}, IsRead: {IsRead}, LikeByUserId: {LikeByUserId}";
        }
    }
}
