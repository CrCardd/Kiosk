
namespace Kiosk.Domain.Models;

public class Combination : BaseModel
{
    //================PROPERTIES================
    
    //================MY-RELATIONS================
    public Variant Comb {get;set;} = null!;
    public Guid CombId {get;set;}
    public Variant Part {get;set;} = null!;
    public Guid PartId {get;set;}
    //================RELATIONS================
}
