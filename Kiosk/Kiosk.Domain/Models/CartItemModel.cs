
namespace Kiosk.Domain.Models;

public class CartItemModel : BaseModel
{
    //================PROPERTIES================
    public required decimal SnapShotPrice {get;set;}


    //================MY-RELATIONS================
    public required CartModel Cart {get;set;}
    public required Guid CartId {get;set;}
    public required CartItemModel? Reference {get;set;}
    public required Guid? ReferenceId {get;set;}
    public required VariantModel Variant {get;set;}
    public required Guid VariantId {get;set;}


    //================RELATIONS================
    public ICollection<IngredientModel> Ingredients {get;set;} = [];
    public ICollection<CartItemModel> CartItems {get;set;} = [];
}
