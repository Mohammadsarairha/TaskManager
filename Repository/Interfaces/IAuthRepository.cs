using Microsoft.AspNetCore.Identity;
using Domain.Interfaces;

namespace Repository.Interfaces
{
    public interface IAuthRepository : IAuthBase<IdentityUser>
    {
    }
}
