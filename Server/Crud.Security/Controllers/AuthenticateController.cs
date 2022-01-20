using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Crud.Authentication.IdentityAuth;
using Crud.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.IdentityModel.Tokens;

namespace Crud.Authentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration configuration;

    public AuthenticateController(UserManager<ApplicationUser> userManager, 
        RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.configuration = configuration;
        
        this.userManager.Options.Password.RequireNonAlphanumeric = false;
        this.userManager.Options.Password.RequireUppercase = false;        
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        var userExists = await userManager.FindByNameAsync(registerModel.UserName);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Message = "User already exists!",
                Status = "Error"
            });
        }

        var user = new ApplicationUser
        {
            Email = registerModel.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registerModel.UserName
        };
        
        var result = await userManager.CreateAsync(user, registerModel.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Message = "User creation failed! Please check user details and try again.",
                Status = "Error"
            });
        }

        return Ok(new Response
        {
            Message = "User created successfully!",
            Status = "Success"
        });
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        var userExists = await userManager.FindByNameAsync(model.UserName);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Message = "User already exists!",
                Status = "Error"
            });
        }

        var user = new ApplicationUser
        {
            Email = model.Email,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            UserName = model.UserName
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Message = "User creation failed! Please check user details and try again.",
                Status = "Error"
            });
        }

        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        }

        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        if (await roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await userManager.AddToRoleAsync(user, UserRoles.Admin);
        }
        
        return Ok(new Response
        {
            Status = "Success",
            Message = "User created successfully!"
        });
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await userManager.FindByNameAsync(model.UserName);
        if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JwtToken:Issuer"],
                audience: configuration["JwtToken:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });            
        }

        return Unauthorized();
    }
    
}