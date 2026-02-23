
namespace Kiosk.Domain.Models;

public class Ingredient : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    //================MY-RELATIONS================

    //================RELATIONS================
    public ICollection<ProductIngredient> ProductIngredients {get;set;} = [];
}
