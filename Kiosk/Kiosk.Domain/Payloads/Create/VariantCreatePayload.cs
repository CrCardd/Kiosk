namespace Kiosk.Domain.Payloads.Create;

public record VariantCreatePayload
(
    string Name,
    decimal Price,
    string Image,
    int Ingredients,
    bool Surpass,
    bool Available,
    Guid ServiceId
);