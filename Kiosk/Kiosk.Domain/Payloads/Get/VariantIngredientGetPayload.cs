namespace Kiosk.Domain.Payloads.Get;

public record VariantIngredientGetPayload
(
    Guid Id,
    bool Available,
    Guid VariantId,
    Guid IngredientId
);