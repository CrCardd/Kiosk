namespace Kiosk.Application.Payloads.Organization;

public record CreatePayload
{
    public required string Name {get;init;}
    public required string Password {get;set;}
}