namespace Kiosk.Domain.Payloads.Create;

public record CartCreatePayload(
    string Client,
    string SessionToken
);