
namespace Kiosk.Domain.Models;

public class Variant : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Image {get;set;}
    public int Ingredients {get;set;}
    // public int MaxIngredients {get;set;}
    public bool Surpass {get;set;}
    public required bool Available {get;set;}
    //================MY-RELATIONS================
    public required Service Service {get;set;}
    public required Guid ServiceId {get;set;}
    //================RELATIONS================
    public ICollection<CartItem> CartItems {get;set;} = [];
    public ICollection<PriceHistoryVariant> PriceHistoryVariants {get;set;} = [];
    public ICollection<Combination> Combs {get;set;} = [];
    public ICollection<Combination> Parts {get;set;} = [];
    public ICollection<VariantIngredient> VariantIngredients {get;set;} = [];
}
