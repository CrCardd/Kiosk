namespace Kiosk.Domain.Payloads.Service;

public record CreatePayload
(
    string Name,
    string Image,
    bool Available
);