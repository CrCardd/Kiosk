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

public record GetService(
    Guid Id,
    string Name,
    string Image
);