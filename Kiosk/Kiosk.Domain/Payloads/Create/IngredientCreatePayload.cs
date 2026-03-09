namespace Kiosk.Domain.Payloads.Create;

public record IngredientCreatePayload
(
    string Name,
    decimal Price,
    bool Available,
    Guid ServiceId,
    int? Quantity = null
);