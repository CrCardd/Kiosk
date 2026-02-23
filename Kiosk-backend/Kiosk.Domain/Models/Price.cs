
namespace Kiosk.Domain.Models;

public class Price : BaseModel
{
    //================PROPERTIES================
    public required decimal Value {get;set;}
    //================MY-RELATIONS================
    public required Product Product {get;set;}
    public required Guid ProductId {get;set;}
    //================RELATIONS================
    
}
