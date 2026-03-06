
namespace Kiosk.Domain.Models;

public class Cart : BaseModel
{
    //================PROPERTIES================
    public required string SessionToken {get;set;}

    //================MY-RELATIONS================

    //================RELATIONS================
    public required Order Order {get;set;}
    public required Guid OderId {get;set;}
    public ICollection<CartItem> CartItems {get;set;} = [];
}
