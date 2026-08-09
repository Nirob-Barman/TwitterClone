
namespace TwitterClone.Domain.Entities
{
    public class Notification
    {
        private Guid _id;
        private Guid _userId;
        private string _type;
        private string _message;
        private DateTime _createdAt;
        private bool _isRead;

        public Notification(Guid userId, string type, string message)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _type = type;
            _message = message;
            _createdAt = DateTime.UtcNow;
            _isRead = false;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public Guid UserId
        {
            get { return _userId; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }
    }
}
