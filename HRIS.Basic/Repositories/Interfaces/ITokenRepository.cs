using System.Security.Claims;
using HRIS.Basic.Models.Domain.Auth;

namespace HRIS.Basic.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(ApplicationUser user, List<string> roles, List<Claim> claims);
    }
}
