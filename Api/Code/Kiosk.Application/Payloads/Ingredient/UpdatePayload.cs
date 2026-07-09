using Kiosk.Application.Payloads._Util;

namespace Kiosk.Application.Payloads.Ingredient;

public record UpdatePayload
{
    public required Guid Id {get;init;}
    public UpdateObject<string?> Name {get;init;} = new UpdateObject<string?>{HasChanged=false, Value=null};
    public UpdateObject<decimal?> Price {get;init;} = new UpdateObject<decimal?>{HasChanged=false, Value=null};
    public UpdateObject<bool?> Available {get;init;} = new UpdateObject<bool?>{HasChanged=false, Value=null};
    public UpdateObject<Guid?> ServiceId {get;init;} = new UpdateObject<Guid?>{HasChanged=false, Value=null};
    public UpdateObject<int?> Quantity {get;init;} = new UpdateObject<int?>{HasChanged=false, Value=null};
}