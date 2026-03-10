namespace Kiosk.Domain.Payloads.Service;

public record GetPayload
(
    Guid Id,
    string Name,
    string Image,
    bool Available,
    ICollection<GetVariant> Variants
);

public record GetVariant
(
    Guid Id,
    string Name,
    decimal Price,
    string Image,
    int Ingredients,
    bool Surpass,
    bool Available,
    ICollection<GetVariant> Parts,
    ICollection<GetVariantIngredient> VariantIngredients
);
public record GetVariantIngredient
(
    Guid Id,
    bool Available,
    GetIngredient Ingredient
);
public record GetIngredient
(
    Guid Id,
    bool Available,
    string Name,
    decimal Price
);