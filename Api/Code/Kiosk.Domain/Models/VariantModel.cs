
namespace Kiosk.Domain.Models;

public class VariantModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Image {get;set;}
    public int Ingredients {get;set;}
    public bool Surpass {get;set;}
    public required bool Available {get;set;}
    //================MY-RELATIONS================
    public required ServiceModel Service {get;set;}
    public required Guid ServiceId {get;set;}
    //================RELATIONS================
    public ICollection<CartItemModel> CartItems {get;set;} = [];
    public ICollection<PriceHistoryVariantModel> PriceHistoryVariants {get;set;} = [];
    public ICollection<CombinationModel> Combs {get;set;} = [];
    public ICollection<CombinationModel> Parts {get;set;} = [];
    public ICollection<VariantIngredientModel> VariantIngredients {get;set;} = [];
}
