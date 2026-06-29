using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.CartItem;

public record GetPayload
{
    public required Guid Id {get;init;}
    public required decimal SnapShotPrice {get;init;}
    public required ICollection<GetPayload> CartItems {get;init;}
    public required string Service {get;init;}
    public required string Variant {get;init;}
    public required ICollection<GetIngredient> Ingredients {get;init;}

    public static GetPayload ToDto(CartItemModel cartItem)
    {
        return new GetPayload
        {
            Id = cartItem.Id,
            CartItems = cartItem.CartItems.Select(ToDto).ToList(),
            Ingredients = cartItem.Ingredients.Select(GetIngredient.ToDto).ToList(),
            Service = cartItem.Variant.Service.Name,
            SnapShotPrice = cartItem.SnapShotPrice,
            Variant = cartItem.Variant.Name
        };
    }
}

public record GetIngredient{
    public required Guid Id {get;init;}
    public required string Name {get;init;}

    public static GetIngredient ToDto(IngredientModel ingredient)
    {
        return new GetIngredient
        {
            Id = ingredient.Id,
            Name = ingredient.Name
        };
    }
}