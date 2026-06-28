
namespace Kiosk.Domain.Models;

public class OrderModel : BaseModel
{
    //================PROPERTIES================
    public required string Index {get;set;}
    public required string Code {get;set;}
    public required decimal Total {get;set;}


    //================MY-RELATIONS================
    public required CartModel Cart {get;set;}
    public required Guid CartId {get;set;}

    //================RELATIONS================
}
