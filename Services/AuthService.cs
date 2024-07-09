using E_Commerce.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public static class AuthService
{
   public static JwtSettings CreateToken(IConfiguration configuration)
    {
        JwtSettings token = new JwtSettings();
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(configuration["Token:Key"]));

        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:Expiration"]));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: configuration["Token:Issuer"],
            audience: configuration["Token:Audience"],
            expires: token.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: credentials
            );

        JwtSecurityTokenHandler tokenhandler = new ();
        token.AccessToken=tokenhandler.WriteToken(jwtSecurityToken);

        byte[] numbers = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(numbers);
        token.RefreshToken=Convert.ToBase64String(numbers);

        return token;

    }
}
