using Kiosk.Application.Payloads._Util;

namespace Kiosk.Application.Payloads.Organization;

public record UpdatePayload
{
    public required Guid Id {get;init;}
    public UpdateObject<string?> Name {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
    public UpdateObject<string?> Email {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
    public UpdateObject<string?> Password {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
}