namespace Kiosk.Application.Payloads.CartItem;

public record CreatePayload
{
    public required Guid CartId {get;init;}
    public required Guid VariantId {get;init;}
    public Guid? ReferenceId {get;init;}
    public required ICollection<Guid> Ingredients {get;init;}
}