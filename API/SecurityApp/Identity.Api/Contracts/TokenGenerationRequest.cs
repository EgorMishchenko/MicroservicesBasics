using System.Security.Claims;

namespace Identity.Api.Contracts
{
  public class TokenGenerationRequest
  {
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public IEnumerable<Claim> CustomClaims { get; set; }
  }
}
