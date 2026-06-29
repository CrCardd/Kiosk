
namespace Kiosk.Domain.Models;

public class ServiceModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Image {get;set;}
    public required bool Available {get;set;}
    //================MY-RELATIONS================
    public required OrganizationModel Organization {get;set;}
    public required Guid OrganizationId {get;set;}

    //================RELATIONS================
    public ICollection<VariantModel> Variants {get;set;} = [];
    public ICollection<IngredientModel> Ingredients {get;set;} = [];

}
