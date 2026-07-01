
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.Cart;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Infrastructure.Services;

public class CartService(
    KioskContext ctx
) : ICartService
{
    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var cart = await ctx.Carts
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Ingredients)
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Variant)  
                    .ThenInclude(v => v.Service)
            .FirstOrDefaultAsync(c => c.Id == id);
        if(cart is null)
            return new NotFoundEx("Invalid Cart's Id");

        return GetPayload.ToDto(cart);
    }

    public async Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken)
    {
        var cart = new CartModel
        {
            Client=payload.Client,
            SessionToken=payload.SessionToken
        };

        ctx.Carts.Add(cart);
        await ctx.SaveChangesAsync(cancellationToken);

        return GetPayload.ToDto(cart);
    }
}