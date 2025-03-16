using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Interfaces
{
    public interface ITokenService
    {

        string CreateToken(User user);
    }
}
