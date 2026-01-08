using AuthHub.Application.DTOs;
using AuthHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<Response> AddAsync(RoleDto emp);
    }
}
