
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using Kiosk.Infrastructure.Extensions;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class VariantClientService(
    KioskContext ctx
) : IVariantClientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == payload.ServiceId)
            // .Where(s => s.OrganizationId == OrganizationId)
            .Include(s => s.Organization)
            .FirstOrDefaultAsync(cancellationToken);

        if(service == null)
            throw new NotFoundEx("Referenced Service not found");

        var variant = new VariantModel
        {
            Name=payload.Name,
            Image=payload.Image,
            Ingredients=payload.Ingredients ?? 1,
            Surpass=payload.Surpass ?? false,
            Available=payload.Available ?? true,
            Service=service,
            ServiceId=payload.ServiceId,
            Organization=service.Organization,
            OrganizationId=service.OrganizationId
        };
        var price = new PriceHistoryVariantModel
        {
            Price=payload.Price,
            Variant=variant,
            VariantId=variant.Id
        };
        foreach(var p in payload.Parts ?? [])
        {
            var part = await ctx.Variants
                .Where(v => v.DisabledAt == null)
                .Include(v => v.Service)
                // .Where(v => v.Service.OrganizationId == OrganizationId)
                .FirstOrDefaultAsync(v => v.Id == p, cancellationToken);
            if(part == null)
                throw new NotFoundEx("Invalid Referenced Variant");

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
        
        
        return Result.Created(GetPayload.ToDto(variant));
    }

    public async Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var variant = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.Parts)
            .Include(v => v.Service)
            // .Where(v => v.Service.OrganizationId == OrganizationId)
            .Include(v => v.VariantIngredients)
                .ThenInclude(vi => vi.Ingredient)
                    .ThenInclude(i => i.PriceHistoryIngredients)
            .Include(v => v.PriceHistoryVariants)
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        if(variant == null)
            throw new NotFoundEx("Referenced variant not found");

        ctx.Variants.Remove(variant);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Ok(GetPayload.ToDto(variant)); 
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        var variants = await ctx.Variants
        .Where(v => v.DisabledAt == null)
        .Where(v => available == null ? true : v.Available == available)
        .Include(v => v.Service)
        // .Where(v => v.Service.OrganizationId == OrganizationId)
        .Include(v => v.VariantIngredients)
            .ThenInclude(vi => vi.Ingredient)
        .Include(v => v.PriceHistoryVariants)
        .Include(v => v.VariantIngredients)
            .ThenInclude(vi => vi.Ingredient)
                .ThenInclude(i => i.PriceHistoryIngredients)
        .Select(v => GetPayload.ToDto(v))
        .ToListAsync(cancellationToken);

        var all = new GenericListPayload<GetPayload>{Total = variants.Count, List = variants};
        return Result.Ok(all);
    }

    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var variant = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.Parts)
            .Include(v => v.Service)
            // .Where(v => v.Service.OrganizationId == OrganizationId)
            .Include(v => v.VariantIngredients)
                .ThenInclude(vi => vi.Ingredient)
                    .ThenInclude(i => i.PriceHistoryIngredients)
            .Include(v => v.PriceHistoryVariants)
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        if(variant == null)
            throw new NotFoundEx("Referenced variant not found");

        return Result.Ok(GetPayload.ToDto(variant));
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetByService(Guid serviceId, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .FirstOrDefaultAsync(
                // s => s.OrganizationId == OrganizationId,
                cancellationToken
            );
        if(service is null)
            throw new NotFoundEx("Referenced service not found");

        var variants = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Where(v => v.ServiceId == serviceId)
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Service)
            .Select(v => GetPayload.ToDto(v))
            .ToListAsync(cancellationToken);
        var variantList = new GenericListPayload<GetPayload>{Total = variants.Count, List = variants};
        return Result.Ok(variantList);
    }

    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var variant = await ctx.Variants
            .Where(v => v.DisabledAt == null)
            .Include(v => v.PriceHistoryVariants)
            .Include(v => v.Parts)
            .Include(v => v.Combs)
            .Include(v => v.Service)
            // .Where(v => v.Service.OrganizationId == OrganizationId)
            .FirstOrDefaultAsync(v => v.Id == payload.Id, cancellationToken);
        if(variant == null)
            throw new NotFoundEx("Referenced variant not found");
            
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
                    throw new ConflictEx("Cicular reference is not allowed");

                var newPart = await ctx.Variants
                    .FirstOrDefaultAsync(v => v.Id == variantId, cancellationToken);
                if(newPart == null)
                    throw new NotFoundEx("Referenced variant not found");
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
        return Result.Ok(GetPayload.ToDto(variant));
    }
}