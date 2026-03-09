namespace Kiosk.Domain.Payloads.Get;

public record CartGetPayload(
    Guid Id,
    string Client,
    string SessionToken
);