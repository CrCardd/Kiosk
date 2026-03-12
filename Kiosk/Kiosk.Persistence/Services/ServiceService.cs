
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Service;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Services;

public class ServiceService(
    KioskContext ctx
) : IServiceService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            Name=payload.Name,
            Image=payload.Image,
            Available=payload.Available ?? true
        };

        ctx.Services.Add(service);
        await ctx.SaveChangesAsync(cancellationToken);

        var value = new GetPayload(
            service.Id,
            service.Name,
            service.Image,
            service.Available,
            new List<GetVariant>()
        );

        return value;
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        var value = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => available == null ? true : s.Available == available)
            .Select(s => new GetPayload
            (
                s.Id,
                s.Name,
                s.Image,
                s.Available,
                new List<GetVariant>()
            ))
            .ToListAsync(cancellationToken);
        
        return new GenericListPayload<GetPayload>(value.Count, value);
    }

    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Include(s => s.Variants)    
                .ThenInclude(v => v.PriceHistoryVariants)
            .FirstOrDefaultAsync(s => s.Id == id);
        if(service == null)
            return "Referenced service not found";
        
        return new GetPayload(
            service.Id,
            service.Name,
            service.Image,
            service.Available,
            service.Variants
            .Where(v => v.DisabledAt == null)
            .Select(v =>
                new GetVariant(
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
                    new List<GetVariant>(),
                    new List<GetVariantIngredient>()
                )
            )
            .ToList()
        );
    }

    public async Task<Result<GetPayload>> Update(Guid id, UpdatePayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.Id == id)
            .FirstOrDefault();
        
        if(service == null)
            return "Referenced Service not found";
        
        if(payload.Name != null)
            service.Name = payload.Name;
        if(payload.Image != null)
            service.Image = payload.Image;
        if(payload.Available != null)
            service.Available = (bool)payload.Available;
        
        await ctx.SaveChangesAsync(cancellationToken);
        var value = new GetPayload(
            service.Id,
            service.Name,
            service.Image,
            service.Available,
            new List<GetVariant>()
        );
        return value;
    }
    public async Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == id)
            .FirstOrDefault();
        if(service == null)
            return "Referenced service not found";
            
        service.DisabledAt = DateTime.UtcNow;
        await ctx.SaveChangesAsync(cancellationToken);

        var value = new GetPayload(
            service.Id,
            service.Name,
            service.Image,
            service.Available,
            new List<GetVariant>()
        );
        return value;
    }
}