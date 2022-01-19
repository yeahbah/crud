namespace Crud.Authentication.IdentityAuth;

public record Response
{
    public string? Status { get; init; }
    public string? Message { get; init; }
}