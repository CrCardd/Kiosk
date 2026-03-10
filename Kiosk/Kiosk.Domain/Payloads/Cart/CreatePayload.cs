namespace Kiosk.Domain.Payloads.Cart;

public record CreatePayload(
    string Client,
    string SessionToken
);