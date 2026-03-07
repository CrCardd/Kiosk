namespace Kiosk.Domain.Payloads.Models;

public record CartPayload(
    string Client,
    string SessionToken,
    Guid? Id = null
);