using AuthHub.Application.DTOs;

namespace AuthHub.Application.Interfaces.Services
{
    public interface IUserService 
    {
        Task<Response> AddAsync(RegisterDto user);
        Task<Response> LoginAsync(LoginDto user);
        // Task<User?> GetUserByEmailAsync(string email);
    }
}
