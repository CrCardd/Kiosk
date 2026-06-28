using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.CartItem;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

public class CartItemService(
    KioskContext ctx
) : ICartItemService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var reference = ctx.CartItems
            .Where(ci => ci.DisabledAt == null)
            .FirstOrDefault(ci => ci.Id == payload.ReferenceId);

        var cart = ctx.Carts
            .Where(c => c.DisabledAt == null)
            .FirstOrDefault(c => c.Id == payload.CartId);
        if(cart == null)
            return "Cart referenced not found";

        var variant = ctx.Variants
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Service)
            .Where(v => v.DisabledAt == null)
            .FirstOrDefault(v => v.Id == payload.VariantId);

        if(variant == null)
            return "Variant referenced not found";
        
        decimal? price = variant
            .PriceHistoryVariants
            .Where(phv => phv.DisabledAt == null)
            .OrderByDescending(phv => phv.CreatedAt)
            .FirstOrDefault()
            ?.Price;
        if(price == null)
            return "There is no price for the referenced variant";

        var cartItem = new CartItemModel
        {
            SnapShotPrice=(decimal)price,
            Cart=cart,
            CartId=cart.Id,
            Reference=reference,
            ReferenceId=reference?.Id,
            Variant=variant,
            VariantId=variant.Id
        };
        if(!variant.Surpass)
            return "This Variant may not surpass it's limit";
        foreach(var ing in payload.Ingredients)
        {
            var ingredient = ctx.Ingredients
                .Where(i => i.DisabledAt == null)
                .Include(i => i.PriceHistoryIngredients)
                .FirstOrDefault(i => i.Id == ing);
            if(ingredient == null)
                return "Ingredient referenced not found";
            if(cartItem.Ingredients.Count >= variant.Ingredients)
            {
                decimal? ingPrice = ingredient.PriceHistoryIngredients
                    .Where(phi => phi.DisabledAt == null)
                    .OrderByDescending(phi => phi.CreatedAt)
                    .FirstOrDefault()
                    ?.Price;
                if(ingPrice == null)
                    return "There is no price for the referenced ingredient";
                cartItem.SnapShotPrice += (decimal)ingPrice;
            }
            cartItem.Ingredients.Add(ingredient);
        }

        ctx.CartItems.Add(cartItem);
        await ctx.SaveChangesAsync(cancellationToken);

        return GetPayload.ToDto(cartItem);
    }
}