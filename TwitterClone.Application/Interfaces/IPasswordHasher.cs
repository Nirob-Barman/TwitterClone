using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(UserDto user, string password);
        bool VerifyPassword(UserDto user, string password, string passwordHash);
    }
}
