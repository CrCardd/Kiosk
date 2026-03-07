using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Models;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class CartService(
    KioskContext ctx
) : ICartService
{
    public async Task<CartPayload?> Start(CartPayload payload, CancellationToken cancellationToken)
    {
        var cart = new Cart
        {
            Client=payload.Client,
            SessionToken=payload.SessionToken
        };

        ctx.Carts.Add(cart);
        await ctx.SaveChangesAsync(cancellationToken);

        return new(
            cart.Client,
            cart.SessionToken,
            cart.Id
        );
    }
}