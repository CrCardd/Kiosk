
namespace Kiosk.Domain.Models;

public class Service : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Image {get;set;}
    public bool Available {get;set;} = true;
    //================MY-RELATIONS================

    //================RELATIONS================
    public ICollection<Product> Products {get;set;} = [];
}
