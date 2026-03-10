namespace Kiosk.Domain.Payloads.Ingredient;

public record CreatePayload
(
    string Name,
    decimal Price,
    bool? Available,
    Guid ServiceId,
    int? Quantity
);