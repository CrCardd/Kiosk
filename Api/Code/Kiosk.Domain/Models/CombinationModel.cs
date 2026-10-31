
namespace Kiosk.Domain.Models;

public class CombinationModel : BaseModelWithSegment
{
    //================PROPERTIES================
    //================MY-RELATIONS================
    public VariantModel Comb {get;set;} = null!;
    public Guid CombId {get;set;}
    public VariantModel Part {get;set;} = null!;
    public Guid PartId {get;set;}
    //================RELATIONS================

}
