
namespace Kiosk.Domain.Models;

public class Cart : BaseModel
{
    //================PROPERTIES================
    public required string Client {get;set;}
    public required string SessionToken {get;set;}

    //================MY-RELATIONS================

    //================RELATIONS================
    public Order? Order {get;set;}
    public Guid? OderId {get;set;}
    public ICollection<CartItem> CartItems {get;set;} = [];
}
