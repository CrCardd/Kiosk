
namespace Kiosk.Domain.Models;

public class PriceHistoryIngredientModel : BaseModelWithSegment
{
    //================PROPERTIES================
    public required decimal Price {get;set;}
    //================MY-RELATIONS================
    public required IngredientModel Ingredient {get;set;}
    public required Guid IngredientId {get;set;}
    //================RELATIONS================
}
