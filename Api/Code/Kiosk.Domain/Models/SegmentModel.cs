namespace Kiosk.Domain.Models;

public class SegmentModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    //================MY-RELATIONS================
    public OrganizationModel? Organization {get;set;} = null;
    public Guid? OrganizationId {get;set;} = null;
    //================RELATIONS================
    public ICollection<CodeModel> Codes {get;set;} = [];
    public ICollection<ServiceModel> Services {get;set;} = [];
    public ICollection<VariantModel> Variants {get;set;} = [];
    public ICollection<IngredientModel> Ingredients {get;set;} = [];
    public ICollection<CartModel> Carts {get;set;} = [];
    public ICollection<UserSegmentModel> UserSegments {get;set;} = [];
}