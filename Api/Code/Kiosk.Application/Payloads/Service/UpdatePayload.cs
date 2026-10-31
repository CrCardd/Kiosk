using Kiosk.Application.Payloads._Util;

namespace Kiosk.Application.Payloads.Service;

public record UpdatePayload
{
    public required Guid Id {get;init;}
    public UpdateObject<string> Name {get;init;} = UpdateObject.Empty;
    public UpdateObject<string> Image {get;init;} = UpdateObject.Empty;
    public UpdateObject<bool> Available {get;init;} = UpdateObject.Empty;
}