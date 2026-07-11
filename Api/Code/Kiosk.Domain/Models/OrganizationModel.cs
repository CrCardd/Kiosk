namespace Kiosk.Domain.Models;

public class OrganizationModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public required string Email {get;set;}
    public required string Password {get;set;}
    //================MY-RELATIONS================
    //================RELATIONS================
    public ICollection<CodeModel> Codes {get;set;} = [];
    public ICollection<ServiceModel> Services {get;set;} = [];
    public ICollection<VariantModel> Variants {get;set;} = [];
    public ICollection<IngredientModel> Ingredient {get;set;} = [];
    public ICollection<OAuthProviderModel> Providers {get;set;} = [];
    public ICollection<CartModel> Carts {get;set;} = [];
}