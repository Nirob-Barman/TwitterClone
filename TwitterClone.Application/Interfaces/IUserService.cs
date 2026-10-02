using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        UserDto? CreateUser(CreateUserDto request);
        List<UserDto> GetUsers();
        UserDto? GetUserById(Guid id);
        UserDto? GetUserByEmail(string email);
        UserDto? UpdateUser(Guid id, UpdateUserDto request);
        bool DeleteUser(Guid id);
    }
}
