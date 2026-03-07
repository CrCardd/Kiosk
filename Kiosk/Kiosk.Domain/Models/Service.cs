
namespace Kiosk.Domain.Models;

public class Service : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Image {get;set;}
    public required bool Available {get;set;}
    //================MY-RELATIONS================

    //================RELATIONS================
    public ICollection<Variant> Variants {get;set;} = [];
    public ICollection<Ingredient> Ingredients {get;set;} = [];

}
