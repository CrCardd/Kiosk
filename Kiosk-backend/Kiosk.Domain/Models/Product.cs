
namespace Kiosk.Domain.Models;

public class Product : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required bool Available {get;set;}
    public int Quantity {get;set;} = 0;
    //================MY-RELATIONS================
    public required Service Service {get;set;}
    public required Guid ServiceId {get;set;}
    //================RELATIONS================
    public ICollection<ProductIngredient> ProductIngredients {get;set;} = [];
    public ICollection<ProductOrder> ProductOrders {get;set;} = [];
    public ICollection<Price> Prices {get;set;} = [];
    
}
