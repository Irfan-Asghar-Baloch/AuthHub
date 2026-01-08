using AuthHub.Application.Interfaces.Repositories;
using AuthHub.Domain.Entities;
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

            return await _context.Users
                .Include(u=>u.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
