namespace Kiosk.Domain.Payloads.Variant;

public record GetPayload
(
    Guid Id,
    string Name,
    decimal Price,
    string Image,
    int Ingredients,
    bool Surpass,
    bool Available,
    Guid ServiceId,
    ICollection<GetIngredient> VariantIngredients
);

public record GetIngredient
(
    Guid Id,
    bool InStock,
    bool Available,
    string Name,
    decimal Price
);
