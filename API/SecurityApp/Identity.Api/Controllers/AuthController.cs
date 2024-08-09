using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Identity.Api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private const string TokenSecret = "MyBestTokenSecret";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);

    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.UTF8.GetBytes(TokenSecret);

      var claims = new List<Claim>()
      {
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new(JwtRegisteredClaimNames.Sub, request.Email),
        new(JwtRegisteredClaimNames.Email, request.Email),
        new("userId", request.UserId.ToString()),
      };

      foreach (var claimPair in request.CustomClaims)
      {
        var jsonElement = (JsonElement)claimPair.Value;
        var valueType = jsonElement.ValueKind switch
        {
          JsonValueKind.True => ClaimValueTypes.Boolean,
          JsonValueKind.False => ClaimValueTypes.Boolean,
          JsonValueKind.Number => ClaimValueTypes.Double,
          _ => ClaimValueTypes.String
        };

        var claim = new Claim(claimPair.Key, claimPair.Value.ToString()!, valueType);
        claims.Add(claim);
      }

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Audience = "asdfg",
        Expires = DateTime.UtcNow.Add(TokenLifetime),
        Issuer = "asdfg",
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Sha512),
        Subject = new ClaimsIdentity(claims)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      var jwt = tokenHandler.WriteToken(token);

      return Ok(jwt);
    }
  }
}
