
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Variant;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Services;

public class _Service(
    KioskContext ctx
) : IVariantService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
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
            Ingredients=payload.Ingredients ?? 1,
            Surpass=payload.Surpass ?? false,
            Available=payload.Available ?? true,
            Service=service,
            ServiceId=payload.ServiceId
        };
        var price = new PriceHistoryVariant
        {
            Price=payload.Price,
            Variant=variant,
            VariantId=variant.Id
        };
        foreach(var p in payload.Parts ?? [])
        {
            var part = ctx.Variants
                .Where(v => v.DisabledAt == null)
                .FirstOrDefault(v => v.Id == p);
            
            if(part == null)
                return "Invalid Referenced Variant";

            ctx.Combinations.Add(
                new Combination{
                    Available=true, 
                    Comb=variant, 
                    CombId=variant.Id, 
                    Part=part, 
                    PartId=part.Id
                }                
            );
        }

        ctx.PriceHistoryVariants.Add(price);
        ctx.Variants.Add(variant);
        await ctx.SaveChangesAsync(cancellationToken);
        
        
        var value = new GetPayload(
            variant.Id,
            variant.Name,
            price.Price,
            variant.Image,
            variant.Ingredients,
            variant.Surpass,
            variant.Available,
            variant.ServiceId,
            []
        );
        return value;
    }

    public async Task<Result<IReadOnlyCollection<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        return await ctx.Variants
        .Where(v => v.DisabledAt == null)
        .Where(v => available == null ? true : v.Available == available)
        .Include(v => v.VariantIngredients)
            .ThenInclude(vi => vi.Ingredient)
        .Include(v => v.PriceHistoryVariants)
        .Select(v => 
            new GetPayload(
                    v.Id,
                    v.Name,
                    v.PriceHistoryVariants
                        .Where(phv => phv.DisabledAt == null)
                        .OrderByDescending(phv => phv.CreatedAt)
                        .First()
                        .Price,
                    v.Image,
                    v.Ingredients,
                    v.Surpass,
                    v.Available,
                    v.ServiceId,
                    new List<GetIngredient>()
            )
        ).ToListAsync(cancellationToken);
    }
}