namespace Kiosk.Domain.Payloads.Get;

public record ServiceGetPayload
(
    Guid Id,
    string Name,
    string Image,
    bool Available
);