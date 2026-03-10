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
    GetService Service,
    ICollection<GetPayload> Parts,
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
public record GetService(
    Guid Id,
    string Name,
    string Image
);