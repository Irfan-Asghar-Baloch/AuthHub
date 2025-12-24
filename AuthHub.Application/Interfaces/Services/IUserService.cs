using AuthHub.Application.DTOs;

namespace AuthHub.Application.Interfaces.Services
{
    public interface IUserService 
    {
        Task<Response> AddAsync(RegisterDto user);
       // Task<User?> GetUserByEmailAsync(string email);
    }
}
