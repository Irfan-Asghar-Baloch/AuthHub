using AuthHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
