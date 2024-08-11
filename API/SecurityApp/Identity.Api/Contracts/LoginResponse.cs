namespace Identity.Api.Contracts
{
  public record LoginResponse(string Email, string Token, List<string> Roles);
}
