
using Kiosk.Domain.Models;
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;
using Kiosk.Domain.Payloads.Update;
using Kiosk.Domain.Services;
using Kiosk.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Services;

public class ServiceService(
    KioskContext ctx
) : IServiceService
{
    public async Task<Result<ServiceGetPayload>> Create(ServiceCreatePayload payload, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            Name=payload.Name,
            Image=payload.Image,
            Available=payload.Available
        };

        ctx.Services.Add(service);
        await ctx.SaveChangesAsync(cancellationToken);

        var value = new ServiceGetPayload(
            service.Id,
            service.Name,
            service.Image,
            service.Available
        );

        return value;
    }

    public async Task<Result<IReadOnlyList<ServiceGetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        var value = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => available == null ? true : s.Available == available)
            .Select(s => new ServiceGetPayload
            (
                s.Id,
                s.Name,
                s.Image,
                s.Available
            ))
            .ToListAsync(cancellationToken);
        
        return value;
    }

    public async Task<Result<ServiceGetPayload>> Update(Guid Id, ServiceUpdatePayload payload, CancellationToken cancellationToken)
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
        var value = new ServiceGetPayload(
            service.Id,
            service.Name,
            service.Image,
            service.Available
        );
        return value;
    }
}