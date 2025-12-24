using AuthHub.Application.DTOs;
using AuthHub.Application.Interfaces.Repositories;
using AuthHub.Application.Interfaces.Services;
using AuthHub.Domain.Entities;

namespace AuthHub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserService(
            IGenericRepository<User> repository,
            IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<Response> AddAsync(RegisterDto user)
        {
            var entity = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password // encrypt later
            };

         var result  = await _repository.AddAsync(entity);

            return new Response
            {
                IsSuccess = true,
                Message = "User registered successfully",
                IsError = false,
                Result = result
            };
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
