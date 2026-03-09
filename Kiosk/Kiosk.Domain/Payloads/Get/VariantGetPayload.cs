namespace Kiosk.Domain.Payloads.Get;

public record VariantGetPayload
(
    Guid Id,
    string Name,
    decimal Price,
    string Image,
    int Ingredients,
    bool Surpass,
    bool Available,
    Guid ServiceId
);