using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Models;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class CartService(
    KioskContext ctx
) : ICartService
{
    public async Task Start(CartPayload payload)
    {
        var cart = new Cart
        {
            Client=payload.Client,
            SessionToken=payload.SessionToken
        };

        ctx.Carts.Add(cart);
        await ctx.SaveChangesAsync();
    }
}