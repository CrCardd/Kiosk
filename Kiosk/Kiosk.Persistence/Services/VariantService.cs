
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;

namespace Kiosk.Persistence.Services;

public class _Service(
    KioskContext ctx
) : IVariantService
{
    public async Task<Result<VariantGetPayload>> Create(VariantCreatePayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            .FirstOrDefault();

        if(service == null)
            return "Referenced Service not found";

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
        var price = new PriceHistoryVariant
        {
            Price=payload.Price,
            Variant=variant,
            VariantId=variant.Id
        };

        ctx.PriceHistoryVariants.Add(price);
        ctx.Variants.Add(variant);
        await ctx.SaveChangesAsync(cancellationToken);
        
        
        var value = new VariantGetPayload(
            variant.Id,
            variant.Name,
            price.Price,
            variant.Image,
            variant.Ingredients,
            variant.Surpass,
            variant.Available,
            variant.ServiceId
        );
        return value;
    }
}