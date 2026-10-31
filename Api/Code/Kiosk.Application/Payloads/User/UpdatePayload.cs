using Kiosk.Application.Payloads._Util;

namespace Kiosk.Application.Payloads.User;

public record UpdatePayload
{
    public UpdateObject<string?> Name {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
    public UpdateObject<string?> Email {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
    public UpdateObject<string?> Password {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
}