
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class CartService(
    KioskContext ctx
) : ICartService
{
    public async Task<Result<CartGetPayload>> Start(CartCreatePayload payload, CancellationToken cancellationToken)
    {
        var cart = new Cart
        {
            Client=payload.Client,
            SessionToken=payload.SessionToken
        };

        ctx.Carts.Add(cart);
        await ctx.SaveChangesAsync(cancellationToken);

        var value = new CartGetPayload(
            cart.Id,
            cart.Client,
            cart.SessionToken
        );
        return value;
    }
}