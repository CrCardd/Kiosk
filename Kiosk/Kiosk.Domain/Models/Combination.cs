
namespace Kiosk.Domain.Models;

public class Combination : BaseModel
{
    //================PROPERTIES================
    public required bool Available {get;set;}
    //================MY-RELATIONS================
    public required Variant Comb {get;set;}
    public required Guid CombId {get;set;}
    public required Variant Part {get;set;}
    public required Guid PartId {get;set;}
    //================RELATIONS================
}
