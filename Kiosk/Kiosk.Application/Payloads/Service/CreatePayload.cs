namespace Kiosk.Application.Payloads.Service;

public record CreatePayload
{
    public required string Name {get;init;}
    public required string Image {get;init;}
    public bool? Available {get;init;}   
}