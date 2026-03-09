
namespace Kiosk.Domain.Models;

public class Ingredient : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public int? Quantity {get;set;}
    public bool Available {get;set;}
    //================MY-RELATIONS================
    public required Service Service {get;set;}
    public required Guid ServiceId {get;set;}
    //================RELATIONS================
    public ICollection<CartItem> CartItems {get;set;} = [];
    public ICollection<PriceHistoryIngredient> PriceHistoryIngredients {get;set;} = [];
    public ICollection<VariantIngredient> VariantIngredients {get;set;} = [];
}
