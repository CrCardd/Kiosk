namespace Kiosk.Application.Payloads.User;

public record CreatePayload
{
    public required string Name {get;init;}
    public required string Email {get;init;}
    public required string Password {get;set;}
}