namespace Kiosk.Application.Payloads.Cart;

public record CreatePayload
{
    public required string Client {get;init;}
    public required string SessionToken {get;init;}
}