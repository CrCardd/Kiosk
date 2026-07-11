
namespace Kiosk.Domain.Models;

public class CartModel : BaseModel
{
    //================PROPERTIES================
    public required string Client {get;set;}
    public required string SessionToken {get;set;}
    //================MY-RELATIONS================
    public required OrganizationModel Organization {get;set;}
    public required Guid OrganizationId {get;set;}
    //================RELATIONS================
    public OrderModel? Order {get;set;}
    public Guid? OrderId {get;set;}
    public ICollection<CartItemModel> CartItems {get;set;} = [];


    public bool IsValidOrganization(Guid organizationId)
    {
        return OrganizationId == organizationId;
    }
}
