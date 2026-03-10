namespace Kiosk.Domain.Payloads.Cart;

public record GetPayload(
    Guid Id,
    string Client,
    string SessionToken
);