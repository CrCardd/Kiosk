
namespace Kiosk.Domain.Models;

public class PriceHistoryIngredientModel : BaseModel
{
    //================PROPERTIES================
    public required decimal Price {get;set;}
    
    //================MY-RELATIONS================
    public required IngredientModel Ingredient {get;set;}
    public required Guid IngredientId {get;set;}

    //================RELATIONS================
}
