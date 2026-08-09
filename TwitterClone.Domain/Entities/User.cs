
namespace TwitterClone.Domain.Entities
{
    public class User
    {
        private Guid _id;
        private string _username;
        private string _email;

        public User(string username, string email)
        {
            _id = Guid.NewGuid();
            _username = username;
            _email = email;
        }

        public Guid Id
        {
            get { return _id; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }

}
