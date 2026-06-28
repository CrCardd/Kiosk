namespace Kiosk.Application.Payloads.VariantIngredient;

public record CreatePayload
{
    public bool? Available {get;init;}
    public required Guid VariantId {get;init;}
    public required Guid IngredientId {get;init;}
}