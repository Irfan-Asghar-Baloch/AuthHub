using AuthHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        public  Task<Role?> GetRoleByNameAsync(string roleName);
        public Task<Role?> GetRoleByIdAsync(long? roleId);

    }
}
