using Microsoft.IdentityModel.Tokens;
using shrt.models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shrt.services;

public class JwtService
{
    private readonly string _secret;
    private readonly int _accessTokenExpirationMinutes;

    public JwtService(string secret, int accessTokenExpirationMinutes)
    {
        _secret = secret;
        _accessTokenExpirationMinutes = accessTokenExpirationMinutes;
    }

    public string GenerateAccessToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(_accessTokenExpirationMinutes),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
