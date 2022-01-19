using System.ComponentModel.DataAnnotations;

namespace Crud.Authentication.Models;

public record LoginModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string? UserName { get; init; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
}