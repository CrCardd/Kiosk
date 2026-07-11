using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.CartItem;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Kiosk.Application.Services.Client;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class CartItemClientService(
    KioskContext ctx
) : ICartItemClientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var reference = await ctx.CartItems
            .Where(ci => ci.DisabledAt == null)
            .FirstOrDefaultAsync(ci => ci.Id == payload.ReferenceId, cancellationToken);

        var cart = await ctx.Carts
            .Where(c => c.DisabledAt == null)
            .FirstOrDefaultAsync(
                // c => c.Id == apiCtx.CartId, 
                cancellationToken
            );
        if(cart == null)
            throw new NotFoundEx("Cart referenced not found");

        var variant = await ctx.Variants
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Service)
            .Where(v => v.DisabledAt == null)
            .FirstOrDefaultAsync(v => v.Id == payload.VariantId, cancellationToken);

        if(variant == null)
            throw new NotFoundEx("Variant referenced not found");
        
        decimal? price = variant.GetCurrentPrice();
        if(price == null)
            throw new ConflictEx("There is no price for the referenced variant");

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
        if(!variant.Surpass && variant.Ingredients < payload.Ingredients.Count)
            throw new ForbiddenEx("This Variant may not surpass it's limit");
        foreach(var ing in payload.Ingredients)
        {
            var ingredient = await ctx.Ingredients
                .Where(i => i.DisabledAt == null)
                .Include(i => i.PriceHistoryIngredients)
                .FirstOrDefaultAsync(i => i.Id == ing, cancellationToken)
                ?? throw new NotFoundEx("Ingredient referenced not found");
            if(cartItem.Ingredients.Count >= variant.Ingredients)
            {
                decimal? ingPrice = ingredient.GetCurrentPrice()
                    ?? throw new ConflictEx("There is no price for the referenced ingredient");
                cartItem.SnapShotPrice += (decimal)ingPrice;
            }
            cartItem.Ingredients.Add(ingredient);
        }

        ctx.CartItems.Add(cartItem);
        await ctx.SaveChangesAsync(cancellationToken);

        return Result.Created(GetPayload.ToDto(cartItem));
    }
}