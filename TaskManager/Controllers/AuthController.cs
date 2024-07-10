using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        //POST : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            return authService.Register(registerDto);
        }

        //POST : api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            return authService.Login(loginDto);
        }

        [HttpGet]
        [Authorize]
        public Task<List<IdentityUser>> GetAllUsersAsync()
        {
            return authService.GetAllUsersAsync();
        }

    }
}
