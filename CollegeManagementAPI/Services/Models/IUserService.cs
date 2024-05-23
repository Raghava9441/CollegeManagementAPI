using CollegeManagementAPI.Controllers;
using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Services.Models
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetById(string id);
        Task<User> Register(User user, string password);
        Task<string> GenerateRefreshToken();
        Task<User> GetUserWithRefreshToken(string refreshToken);
        Task RevokeRefreshToken(User user);
    }
}
