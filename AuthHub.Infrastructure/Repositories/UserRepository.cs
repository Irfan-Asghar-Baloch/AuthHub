using AuthHub.Application.Interfaces.Repositories;
using AuthHub.Domain.Entities;
using AuthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace AuthHub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
