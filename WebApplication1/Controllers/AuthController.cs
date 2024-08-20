using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.DTOs;
using project.Interfaces;
using project.Models;

namespace project.Controllers
{
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("/api/registration")]
        public async Task<UserResponse> Registration([FromBody]  RegistrationDTO user)
            
        {
            return await _authService.Registration(user);
        }

        


                    [HttpGet]
                    [Route("showusers")]
                    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
                    {
                    var users = await _authService.GetAllUsers();
                    return Ok(users);
                    }

                




        [HttpPost]
        [Route("/api/login")]
        public async Task<UserResponse> Login([FromBody] LoginDTO user)

        {
            return await _authService.Login(user);
        }










    }
}
