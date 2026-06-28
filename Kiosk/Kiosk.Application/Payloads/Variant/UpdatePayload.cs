using Kiosk.Application.Payloads._Misc;

namespace Kiosk.Application.Payloads.Variant;

public record UpdatePayload
{
    public required UpdateObject<string> Name {get;init;}
    public required UpdateObject<decimal> Price {get;init;}
    public required UpdateObject<string> Image {get;init;}
    public required UpdateObject<int> Ingredients {get;init;}
    public required UpdateObject<bool> Surpass {get;init;}
    public required UpdateObject<bool> Available {get;init;}
    public required UpdateObject<ICollection<Guid>> Parts {get;init;}
}
