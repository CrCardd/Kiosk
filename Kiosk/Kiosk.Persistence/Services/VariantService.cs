using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Models;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Services;

public class _Service(
    KioskContext ctx
) : IVariantService
{
    public async Task<VariantPayload?> Create(VariantPayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            .FirstOrDefault();

        if(service == null)
            return null;

        var variant = new Variant
        {
            Name=payload.Name,
            Image=payload.Image,
            Ingredients=payload.Ingredients,
            Surpass=payload.Surpass,
            Available=payload.Available,
            Service=service,
            ServiceId=payload.ServiceId
        };
        ctx.Variants.Add(variant);
        await ctx.SaveChangesAsync(cancellationToken);
        return new(
            variant.Name,
            variant.Image,
            variant.Ingredients,
            variant.Surpass,
            variant.Available,
            variant.ServiceId,
            variant.Id
        );
    }
}