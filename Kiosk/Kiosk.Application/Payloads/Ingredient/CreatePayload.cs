namespace Kiosk.Application.Payloads.Ingredient;

public record CreatePayload
{
    public required string Name {get;init;}
    public required decimal Price {get;init;}
    public bool? Available {get;init;}
    public required Guid ServiceId {get;init;}
    public int? Quantity {get;init;}   
}