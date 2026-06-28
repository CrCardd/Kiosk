
namespace Kiosk.Domain.Models;

public class VariantIngredientModel : BaseModel
{
    //================PROPERTIES================
    public required bool Available {get;set;}
    
    //================MY-RELATIONS================
    public required VariantModel Variant {get;set;}
    public required Guid VariantId {get;set;}
    public required IngredientModel Ingredient {get;set;}
    public required Guid IngredientId {get;set;}
    //================RELATIONS================
}
