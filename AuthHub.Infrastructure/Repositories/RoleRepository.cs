using AuthHub.Application.Interfaces.Repositories;
using AuthHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
         _context = context;   
        }
     public  async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(x=>x.Name==roleName);
           
        }

       public async Task<Role?> GetRoleByIdAsync(long? roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
        }

       
    }
}
