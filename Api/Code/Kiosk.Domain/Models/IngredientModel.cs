
namespace Kiosk.Domain.Models;

public class IngredientModel : BaseModel
{
    //================PROPERTIES================
    public required string Name {get;set;}
    public int? Quantity {get;set;}
    public bool Available {get;set;}
    //================MY-RELATIONS================
    public required OrganizationModel Organization {get;set;}
    public required Guid OrganizationId {get;set;}
    public required ServiceModel Service {get;set;}
    public required Guid ServiceId {get;set;}
    //================RELATIONS================
    public ICollection<CartItemModel> CartItems {get;set;} = [];
    public ICollection<PriceHistoryIngredientModel> PriceHistoryIngredients {get;set;} = [];
    public ICollection<VariantIngredientModel> VariantIngredients {get;set;} = [];
    //================METHODS================
    public decimal? GetCurrentPrice()
    {
        return PriceHistoryIngredients
            .Where(p => p.DisabledAt == null)
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => p.Price)
            .FirstOrDefault();
    }
    public bool IsValidOrganization(Guid organizationId)
    {
        return Service.IsValidOrganization(organizationId);
    } 
}   
