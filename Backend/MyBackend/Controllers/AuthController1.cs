using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace MyBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController1 : ControllerBase
{
    private readonly string _issuer = "http://localhost:5113";
    private readonly string _audience = "http://localhost:3000";
    private readonly string _secretKey = "my-super-secure-key123-!!!@1112Hh";

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        switch (request.Username)
        {
            case "admin" when request.Password == "password":
            {
                var token = GenerateJwtToken();
                Console.WriteLine(token);
                return Ok(new { Token = token });
            }
            default:
                return Unauthorized();
        }
    }

    private string GenerateJwtToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, "admin"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
