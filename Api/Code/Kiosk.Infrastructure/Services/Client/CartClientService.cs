
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads.Cart;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Kiosk.Application.Services.Client;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Utils;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class CartClientService(
    KioskContext ctx
) : ICartClientService
{
    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var cart = await ctx.Carts
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Ingredients)
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Variant)  
                    .ThenInclude(v => v.Service)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if(cart is null)
            throw new NotFoundEx("Invalid Cart's Id");

        return Result.Ok(GetPayload.ToDto(cart));
    }

    public async Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken)
    {
        var organization = await ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
                // o => o.Id ==apiCtx.OrganizationId, 
                cancellationToken
            );
        if(organization == null)
            throw new NotFoundEx("organization not found");

        var cart = new CartModel
        {
            Client=payload.Client,
            SessionToken=RandomCodeGenerator.Generate("ABCDEFGHIJKLMNOPQRSTUVWXYZ",8),
            Organization=organization,
            OrganizationId=organization.Id
        };

        ctx.Carts.Add(cart);
        await ctx.SaveChangesAsync(cancellationToken);

        return Result.Created(GetPayload.ToDto(cart));
    }
}