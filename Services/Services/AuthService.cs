using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using Repository.Repositories;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AuthService(UserManager<IdentityUser> userManager , IAuthRepository authRepository)
        {
            this.userManager = userManager;
            this.authRepository = authRepository;
        }

        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
                return new BadRequestObjectResult("Passwords do not match. Please try again");
            var userMail = await userManager.FindByEmailAsync(registerDto.Email);
            var userName = await userManager.FindByNameAsync(registerDto.UserName);
            if (userMail != null && userName != null)
                return new BadRequestObjectResult("Email and UserName already used");

            if (userMail != null)
                return new BadRequestObjectResult("Email already used");

            if (userName != null)
                return new BadRequestObjectResult("UserName already used");

            var identityUser = new IdentityUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerDto.Password);

            if (identityResult.Succeeded)
                return new OkObjectResult("User was registered !");

            return new BadRequestObjectResult("Something went wronge");
        }
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (loginDto.UserName != null)
            {
                var user = await userManager.FindByEmailAsync(loginDto.UserName);
                if (user != null)
                {
                    var checkPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);
                    if (checkPassword)
                    {
                        var jwtToken = authRepository.CreateJWTToken(user);
                        return new OkObjectResult(jwtToken);
                    }
                }
            }
            return new BadRequestObjectResult("UserName or Password incorrect");
        }
        public async Task<List<IdentityUser>> GetAllUsersAsync()
        {
            var users = await userManager.Users.ToListAsync();

            return users;
        }

    }
}
