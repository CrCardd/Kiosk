
namespace Kiosk.Domain.Models;

public class Order : BaseModel
{
    
    //================PROPERTIES================
    public required string Client {get;set;}
    public required string Index {get;set;}
    public required string Code {get;set;}
    public required decimal Total {get;set;}
    
    //================MY-RELATIONS================

    //================RELATIONS================
    public ICollection<ProductOrder> ProductOrders {get;set;} = [];
}
