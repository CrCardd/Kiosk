
namespace Kiosk.Domain.Models;

public class CartItem : BaseModel
{
    //================PROPERTIES================
    public required decimal SnapShotPrice {get;set;}


    //================MY-RELATIONS================
    public required Cart Cart {get;set;}
    public required Guid CartId {get;set;}
    public required CartItem? Reference {get;set;}
    public required Guid? ReferenceId {get;set;}
    public required Variant Variant {get;set;}
    public required Guid VariantId {get;set;}


    //================RELATIONS================
    public ICollection<Ingredient> Ingredients {get;set;} = [];
    public ICollection<CartItem> CartItems {get;set;} = [];
}
