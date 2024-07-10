using Domain.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<ActionResult> Register(RegisterDto registerDto);
        Task<ActionResult> Login(LoginDto loginDto);
        Task<List<IdentityUser>> GetAllUsersAsync();
    }
}
