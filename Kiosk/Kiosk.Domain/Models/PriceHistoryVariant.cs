
namespace Kiosk.Domain.Models;

public class PriceHistoryVariant : BaseModel
{
    //================PROPERTIES================
    public required decimal Price {get;set;}
    
    //================MY-RELATIONS================
    public required Variant Variant {get;set;}
    public required Guid VariantId {get;set;}

    //================RELATIONS================
}
