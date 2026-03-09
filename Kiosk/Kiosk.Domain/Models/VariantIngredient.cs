
namespace Kiosk.Domain.Models;

public class VariantIngredient : BaseModel
{
    //================PROPERTIES================
    public required bool Available {get;set;}
    
    //================MY-RELATIONS================
    public required Variant Variant {get;set;}
    public required Guid VariantId {get;set;}
    public required Ingredient Ingredient {get;set;}
    public required Guid IngredientId {get;set;}
    //================RELATIONS================
}
