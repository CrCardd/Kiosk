namespace Kiosk.Domain.Payloads.Variant;

public record CreatePayload
(
    string Name,
    decimal Price,
    string Image,
    int Ingredients,
    bool Surpass,
    bool Available,
    Guid ServiceId,
    ICollection<Guid> Parts
);