namespace Kiosk.Domain.Payloads.VariantIngredient;

public record CreatePayload
(
    bool Available,
    Guid VariantId,
    Guid IngredientId
);