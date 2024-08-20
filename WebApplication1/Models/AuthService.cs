using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project.DTOs;
using project.Interfaces;
using project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<User> userManager, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<UserResponse> Registration(RegistrationDTO user)
        {
            var identityUser = new User
            {
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                return new UserResponse
                {
                    Message = "User Created",
                    Success = true,
                };
            }

            return new UserResponse
            {
                Message = "User not Created",
                Success = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }









        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync(); // Fetch all users
        }


        public async Task<UserResponse> Login(LoginDTO user)
        {
            
            var identityUser = await _userManager.FindByNameAsync(user.UserName);
            if (identityUser == null)
            {
                return new UserResponse
                {
                    Message = "User not Found",
                    Success = false,
                };
            }

          
            var result = await _userManager.CheckPasswordAsync(identityUser, user.Password);

            if (result == false)
            {
                return new UserResponse
                {
                    Message = "Password not Correct",
                    Success = false,
                };
            }

            return new UserResponse
            {
                Message = "Login Successful",
                Success = true,
            };
        }









    }
}
