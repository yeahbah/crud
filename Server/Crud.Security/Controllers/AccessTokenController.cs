using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Crud.Authentication.Controllers;

[Authorize]
public class AccessTokenController : Controller
{
    private readonly IConfiguration configuration;

    public AccessTokenController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    [HttpGet]
    public async Task<IEnumerable<string>> Get()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        return new[] { accessToken };
    }

    private string BuildJWToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JwtToken:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var issuer = this.configuration["JwtToken:Issuer"];
        var audience = this.configuration["JwtToken:Audience"];
        var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(this.configuration["JwtToken:TokenExpiration"]));

        var token = new JwtSecurityToken(issuer, audience, expires: jwtValidity, signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
} 