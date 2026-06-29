
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Services.Extensions;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

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

        var variant = new VariantModel
        {
            Name=payload.Name,
            Image=payload.Image,
            Ingredients=payload.Ingredients ?? 1,
            Surpass=payload.Surpass ?? false,
            Available=payload.Available ?? true,
            Service=service,
            ServiceId=payload.ServiceId
        };
        var price = new PriceHistoryVariantModel
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
                new CombinationModel
                {
                    Part=part,
                    PartId=part.Id,
                }
            );
        }

        ctx.PriceHistoryVariants.Add(price);
        ctx.Variants.Add(variant);

        await ctx.SaveChangesAsync(cancellationToken);
        
        
        return GetPayload.ToDto(variant);
    }

    public async Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var variant = await ctx.Variants
            // .Where(v => v.DisabledAt == null)
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

        var variantPayload = GetPayload.ToDto(variant);
        ctx.Variants.Remove(variant);

        await ctx.SaveChangesAsync(cancellationToken);
        return variantPayload; 
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
        .Select(v => GetPayload.ToDto(v))
        .ToListAsync(cancellationToken);

        return new GenericListPayload<GetPayload>{Total = variants.Count, List = variants};
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

        return GetPayload.ToDto(variant);
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetByService(Guid serviceId, CancellationToken cancellationToken)
    {
        if(!ctx.Services.Any(s => s.Id == serviceId))
            return "Referenced service not found";

        var variants = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Service)
            .Select(v => GetPayload.ToDto(v))
            .ToListAsync(cancellationToken);
        return new GenericListPayload<GetPayload>{Total = variants.Count, List = variants};
    }

    public async Task<Result<GetPayload>> Update(Guid id, UpdatePayload payload, CancellationToken cancellationToken)
    {
        var variant = ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Parts)
            .Include(v => v.Combs)
            .Include(v => v.Service)
            .FirstOrDefault(v => v.Id == id);
        if(variant == null)
            return "Referenced variant not found";
            
        if(payload.Price.HasChanged)
        {
            var newPrice = new PriceHistoryVariantModel
            {
                Price=payload.Price.Value,
                Variant=variant,
                VariantId=variant.Id
            };
            ctx.PriceHistoryVariants.Add(newPrice);
        }

        if(payload.Parts.HasChanged)
        {
            foreach(var partId in variant.Parts.Where(p => p.DisabledAt == null).Select(p => p.PartId).MultExcept(payload.Parts.Value))
            {
                //DELETE
                variant.Parts
                    .First(p => p.PartId == partId)
                    .DisabledAt = DateTime.UtcNow;
            }

            foreach(var variantId in payload.Parts.Value.MultExcept(variant.Parts.Where(p => p.DisabledAt == null).Select(p => p.PartId)))
            {
                //CREATE/REACTIVE
                if(variant.Id == variantId)
                    return "Cicular reference is not allowed";

                var newPart = ctx.Variants
                    .FirstOrDefault(v => v.Id == variantId);
                if(newPart == null)
                    return "Referenced variant not found";
                var existedDisabledPart = variant.Parts
                    .Where(p => p.DisabledAt != null)
                    .FirstOrDefault(p => p.PartId == variantId);
                if(existedDisabledPart != null)
                    existedDisabledPart.DisabledAt = null;
                else
                    ctx.Add(new CombinationModel{CombId=variant.Id , PartId=newPart.Id});
            }  
        }

        if(payload.Name.HasChanged)
            variant.Name = payload.Name.Value;
        if(payload.Image.HasChanged)
            variant.Image = payload.Image.Value;
        if(payload.Ingredients.HasChanged)
            variant.Ingredients = payload.Ingredients.Value;
        if(payload.Surpass.HasChanged)
            variant.Surpass = payload.Surpass.Value;
        if(payload.Available.HasChanged)
            variant.Available = payload.Available.Value;
        

        await ctx.SaveChangesAsync(cancellationToken);
        
        var price = variant.PriceHistoryVariants
            .Where(phv => phv.DisabledAt == null)
            .OrderByDescending(phv => phv.CreatedAt)
            .First();
        
        var value = GetPayload.ToDto(variant);
        return value;
    }
}