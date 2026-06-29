
namespace Kiosk.Domain.Models;

public class PriceHistoryVariantModel : BaseModel
{
    //================PROPERTIES================
    public required decimal Price {get;set;}
    
    //================MY-RELATIONS================
    public required VariantModel Variant {get;set;}
    public required Guid VariantId {get;set;}

    //================RELATIONS================
}
