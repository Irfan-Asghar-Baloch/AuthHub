using AuthHub.Application.DTOs;
using AuthHub.Application.Interfaces.Repositories;
using AuthHub.Application.Interfaces.Security;
using AuthHub.Application.Interfaces.Services;
using AuthHub.Domain.Entities;

namespace AuthHub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userrepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IRoleRepository _roleRepository;   
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public UserService( 
            IGenericRepository<User> userrepository,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher, 
            IJwtTokenGenerator jwtTokenGenerator , 
            IGenericRepository<Employee> employeeRepository,
            IRoleRepository roleRepository
            ) 
        {
            _userrepository = userrepository;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Response> AddAsync(RegisterDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password is required");
            var existingUser  = await _userRepository.GetByEmailAsync(user.Email!);
            if (existingUser != null)
                throw new InvalidOperationException("User with this email already exists");
            var role = await _roleRepository.GetRoleByIdAsync(user.RoleId);
            if (role == null)
                throw new InvalidOperationException("Role does not exist");
            var hashedPassword = _passwordHasher.Hash(user.Password); 

            var entity = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = hashedPassword, 
                RoleId =role.Id
            };
          var result =  await _userrepository.AddAsync(entity);
            var emp = new Employee
            {
                Name = user.Name,
                Email = user.Email,
                UserId = result.Id
            };
            await _employeeRepository.AddAsync(emp);
            return new Response
            {
                IsSuccess = true,
                Message = "User registered successfully",
                Result = new RegisterResponseDto
                {
                    Id = result.Id,
                    Name = result.Name!,
                    Email = result.Email!,
                    RoleId = role.Id!
                },
                IsError = false
            };
        }

        public async Task<Response> LoginAsync(LoginDto user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email!);
            if (existingUser == null)
                return new Response
                {
                    IsSuccess = false,
                    Message = "Invalid email or password",
                    IsError = true,
                };
            var isPasswordValid = _passwordHasher.Verify(user.Password!, existingUser.Password);
            if (!isPasswordValid)
                return new Response
                {
                    IsSuccess = false,
                    Message = "Invalid email or password",
                    IsError = true,
                };
            var token = _jwtTokenGenerator.GenerateToken(existingUser);
            return new Response
            {
                IsSuccess = true,
                Message = "Login successful",
                Result = new { Token = token },
                IsError = false,
            };
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
