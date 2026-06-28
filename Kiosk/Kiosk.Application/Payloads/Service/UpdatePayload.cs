using Kiosk.Application.Payloads._Misc;

namespace Kiosk.Application.Payloads.Service;

public record UpdatePayload
{
    public required UpdateObject<string> Name {get;init;}
    public required UpdateObject<string> Image {get;init;}
    public required UpdateObject<bool> Available {get;init;}
}