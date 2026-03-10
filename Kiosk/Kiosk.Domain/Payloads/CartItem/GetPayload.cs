namespace Kiosk.Domain.Payloads.CartItem;

public record GetPayload(
    Guid Id,
    decimal SnapShotPrice,
    ICollection<GetPayload> CartItems,
    string Service,
    string Variant,
    ICollection<GetIngredient> Ingredients
);
public record GetIngredient
(
    Guid Id,
    string Name
);