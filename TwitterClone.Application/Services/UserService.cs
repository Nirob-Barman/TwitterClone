using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }).ToList();
        }

        public UserDto? GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public UserDto? GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public UserDto CreateUser(CreateUserDto request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName) || string.IsNullOrWhiteSpace(request.Email))
            {
                return null!;
            }

            var existingUser = _userRepository.GetUserByEmail(request.Email);

            if (existingUser != null)
            {
                return null!;
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _userRepository.AddUser(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public UserDto UpdateUser(Guid id, UpdateUserDto request)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null!;
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            _userRepository.UpdateUser(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public bool DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return false;
            }

            return _userRepository.DeleteUser(user);
        }
    }
}
