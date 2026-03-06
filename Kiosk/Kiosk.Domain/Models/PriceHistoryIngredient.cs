
namespace Kiosk.Domain.Models;

public class PriceHistoryIngredient : BaseModel
{
    //================PROPERTIES================
    public required decimal Price {get;set;}
    
    //================MY-RELATIONS================
    public required Ingredient Ingredient {get;set;}
    public required Guid IngredientId {get;set;}

    //================RELATIONS================
}
