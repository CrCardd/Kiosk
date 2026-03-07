namespace Kiosk.Domain.Payloads.Models;

public record IngredientPayload
(
    string Name,
    bool Available,
    Guid ServiceId,
    int? Quantity = null,
    Guid? Id = null
);