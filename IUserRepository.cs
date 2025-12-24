using System.Threading.Tasks;
using AuthHub.Domain.Entities;

namespace AuthHub.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
    }
}