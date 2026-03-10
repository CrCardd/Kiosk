
namespace Kiosk.Domain.Models;

public class Combination : BaseModel
{
    //================PROPERTIES================
    
    //================MY-RELATIONS================
    public Variant Comb {get;set;}
    public Guid CombId {get;set;}
    public Variant Part {get;set;}
    public Guid PartId {get;set;}
    //================RELATIONS================
}
