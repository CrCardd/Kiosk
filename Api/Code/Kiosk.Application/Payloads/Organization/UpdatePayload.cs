using Kiosk.Application.Payloads._Util;

namespace Kiosk.Application.Payloads.Organization;

public record UpdatePayload
{
    public UpdateObject<string?> Name {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
}