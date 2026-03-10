namespace Kiosk.Domain.Payloads.Service;

public record GetPayload
(
    Guid Id,
    string Name,
    string Image,
    bool Available
);