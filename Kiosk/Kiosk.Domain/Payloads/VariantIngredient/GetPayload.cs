namespace Kiosk.Domain.Payloads.VariantIngredient;

public record GetPayload
(
    Guid Id,
    bool Available,
    GetVariant Variant,
    GetIngredient Ingredient
);

public record GetVariant(
    Guid Id,
    string Name
);
public record GetIngredient(
    Guid Id,
    string Name
);