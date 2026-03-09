namespace Kiosk.Domain.Payloads.Create;

public record VariantIngredientCreatePayload
(
    bool Available,
    Guid VariantId,
    Guid IngredientId
);