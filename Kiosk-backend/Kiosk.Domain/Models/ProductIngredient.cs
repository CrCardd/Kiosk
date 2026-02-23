
namespace Kiosk.Domain.Models;

public class ProductIngredient : BaseModel
{
    //================PROPERTIES================
    public decimal? Weight {get;set;}
    //================MY-RELATIONS================
    public required Product Product {get;set;}
    public required Guid ProductId {get;set;}
    public required Ingredient Ingredient {get;set;}
    public required Guid IngredientId {get;set;}
    //================RELATIONS================
    
}
