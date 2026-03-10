
using Kiosk.Domain.Models;
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
            service.Available
        );

        return value;
    }

    public async Task<Result<IReadOnlyCollection<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        var value = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => available == null ? true : s.Available == available)
            .Select(s => new GetPayload
            (
                s.Id,
                s.Name,
                s.Image,
                s.Available
            ))
            .ToListAsync(cancellationToken);
        
        return value;
    }

    public async Task<Result<GetPayload>> Update(Guid Id, UpdatePayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.Id == Id)
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
            service.Available
        );
        return value;
    }
}