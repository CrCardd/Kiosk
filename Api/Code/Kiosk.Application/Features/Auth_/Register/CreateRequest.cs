namespace Kiosk.Application.Features.Auth_.Register;

public record CreateRequest
{
    public required string Name {get;init;}
    public required string Password {get;set;}
}