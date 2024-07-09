using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using E_Commerce.Entities;
using E_Commerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ECommerceDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public AuthController(ECommerceDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _configuration = configuration;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(Users user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return Ok(new { message = "User created successfully!" });
    }

    [HttpPost("login")]
    public IActionResult Login(Users user)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        if (existingUser == null)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, existingUser.UserName)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],  // Bu satırı eklediğinizden emin olun
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { token = tokenHandler.WriteToken(token) });
    }
}
