using AuthHub.Application.DTOs;
using AuthHub.Application.Interfaces.Repositories;
using AuthHub.Application.Interfaces.Services;
using AuthHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Services
{
    public class RoleService :IRoleService
    {
        private readonly IGenericRepository<Role> _genericRepository;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IGenericRepository<Role> genericRepository, IRoleRepository roleRepository)
        {
            _genericRepository = genericRepository;
           _roleRepository = roleRepository;

        }

        public async Task<Response> AddAsync(RoleDto role)
        {
            if (role == null || string.IsNullOrWhiteSpace(role.Name))
                return new Response
                {
                    IsSuccess = false,
                    IsError = true,
                    Message = "Invalid role data",
                    Result = null
                };

            var isRole = await _roleRepository.GetRoleByNameAsync(role.Name);
            if (isRole!=null)
                return new Response
                {
                    IsSuccess = false,
                    IsError = true,
                    Message = "Role already exists with this name",
                    Result = null
                };

            var newRole = new Role
            {
                Name = role.Name.Trim(),
                Description = role.Description?.Trim()
            };

            var result = await _genericRepository.AddAsync(newRole);

            return new Response
            {
                IsSuccess = true,
                IsError = false,
                Message = "Role successfully added",
                Result = result
            };
        }

    }
}
