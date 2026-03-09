namespace Kiosk.Domain.Payloads.Get;

public record IngredientGetPayload
(
    Guid Id,
    string Name,
    decimal Price,
    bool Available,
    Guid ServiceId,
    int? Quantity = null
);