namespace Kiosk.Domain.Payloads.Models;

public record VariantPayload
(
    string Name,
    string Image,
    int Ingredients,
    bool Surpass,
    bool Available,
    Guid ServiceId,
    Guid? Id = null
);