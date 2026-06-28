using Kiosk.Application.Payloads._Misc;

namespace Kiosk.Application.Payloads.Ingredient;

public record UpdatePayload
{
    public required UpdateObject<string> Name {get;init;}
    public required UpdateObject<decimal> Price {get;init;}
    public required UpdateObject<bool> Available {get;init;}
    public required UpdateObject<Guid> ServiceId {get;init;}
    public required UpdateObject<int?> Quantity {get;init;}
}