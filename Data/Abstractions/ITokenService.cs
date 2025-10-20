using System.Security.Claims;
using Data.Identity;
namespace Data.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
