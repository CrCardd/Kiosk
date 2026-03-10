namespace Kiosk.Domain.Payloads.Ingredient;

public record GetPayload
(
    Guid Id,
    string Name,
    decimal Price,
    bool Available,
    Guid ServiceId,
    int? Quantity = null
);