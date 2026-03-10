
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Cart;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class CartService(
    KioskContext ctx
) : ICartService
{
    public async Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken)
    {
        var cart = new Cart
        {
            Client=payload.Client,
            SessionToken=payload.SessionToken
        };

        ctx.Carts.Add(cart);
        await ctx.SaveChangesAsync(cancellationToken);

        var value = new GetPayload(
            cart.Id,
            cart.Client,
            cart.SessionToken
        );
        return value;
    }
}