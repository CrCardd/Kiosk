
using System.IO.Pipes;
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Variant;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Services;

public class VariantService(
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

            variant.Parts.Add(
                new Combination
                {
                    Part=part,
                    PartId=part.Id,
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
            new(variant.Service.Id,variant.Service.Name,variant.Service.Image),
            [],
            []
        );
        return value;
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        var variants = await ctx.Variants
        .Where(v => v.DisabledAt == null)
        .Where(v => available == null ? true : v.Available == available)
        .Include(v => v.Service)
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
                    new(v.Service.Id,v.Service.Name,v.Service.Image),
                    new List<GetPayload>(),
                    new List<GetVariantIngredient>()
            )
        ).ToListAsync(cancellationToken);

        return new GenericListPayload<GetPayload>(variants.Count, variants);
    }

    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {


        var variant = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.Parts)
            .Include(v => v.Service)
            .Include(v => v.VariantIngredients)
                .ThenInclude(vi => vi.Ingredient)
                    .ThenInclude(i => i.PriceHistoryIngredients)
            .Include(v => v.PriceHistoryVariants)
            .FirstOrDefaultAsync(v => v.Id == id);
        if(variant == null)
            return "Referenced variant not found";

        var parts = new List<GetPayload>();
        foreach (var part in variant.Parts)
        {
            var result = await GetById(part.PartId, cancellationToken);
            if (result.IsSuccess)
                parts.Add(result.Value);
        }

        return new GetPayload(
            variant.Id,
            variant.Name,
            variant.PriceHistoryVariants.Where(phv => phv.DisabledAt == null).OrderByDescending(phv => phv.CreatedAt).First().Price,
            variant.Image,
            variant.Ingredients,
            variant.Surpass,
            variant.Available,
            new(variant.Service.Id, variant.Service.Name, variant.Service.Image),
            parts!,
            variant.VariantIngredients
                .Where(vi => vi.DisabledAt == null)
                .Select(vi => new GetVariantIngredient(
                    vi.Id,
                    vi.Available, 
                    new GetIngredient(
                        vi.Ingredient.Id,
                        vi.Ingredient.Available, 
                        vi.Ingredient.Name,
                        vi.Ingredient.PriceHistoryIngredients.Where(phi => phi.DisabledAt == null).OrderByDescending(phi => phi.CreatedAt).First().Price
                    )
                ))
                .ToList()
        );
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetByService(Guid serviceId, CancellationToken cancellationToken)
    {
        if(!ctx.Services.Any(s => s.Id == serviceId))
            return "Referenced service not found";

        var variants = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Service)
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
                        new(v.Service.Id,v.Service.Name,v.Service.Image),
                        new List<GetPayload>(),
                        new List<GetVariantIngredient>()
                )
            )
            .ToListAsync(cancellationToken);
        return new GenericListPayload<GetPayload>(variants.Count, variants);
    }
}