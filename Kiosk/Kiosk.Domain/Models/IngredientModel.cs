
namespace Kiosk.Domain.Models;

public class IngredientModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public int? Quantity {get;set;}
    public bool Available {get;set;}
    //================MY-RELATIONS================
    public required ServiceModel Service {get;set;}
    public required Guid ServiceId {get;set;}
    //================RELATIONS================
    public ICollection<CartItemModel> CartItems {get;set;} = [];
    public ICollection<PriceHistoryIngredientModel> PriceHistoryIngredients {get;set;} = [];
    public ICollection<VariantIngredientModel> VariantIngredients {get;set;} = [];
}
