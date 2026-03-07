namespace Kiosk.Domain.Payloads.Models;

public record ServicePayload
(
    string Name,
    string Image,
    bool Available,
    Guid? Id = null
);