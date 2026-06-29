namespace Kiosk.Application.Features.Auth_;

public record LoginRequest
{
    public required string Login {get;init;}
    public required string Password {get;init;}
}