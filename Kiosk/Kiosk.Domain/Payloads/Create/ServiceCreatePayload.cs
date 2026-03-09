namespace Kiosk.Domain.Payloads.Create;

public record ServiceCreatePayload
(
    string Name,
    string Image,
    bool Available
);