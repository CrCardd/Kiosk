namespace Kiosk.Domain.Payloads.CartItem;

public record CreatePayload(
    Guid CartId,
    Guid VariantId,
    Guid? ReferenceId,
    ICollection<Guid> Ingredients
);