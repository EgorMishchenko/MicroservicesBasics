using Microsoft.AspNetCore.Identity;

namespace Identity.Data.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
