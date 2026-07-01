
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Infrastructure.Services;

public class ServiceService(
    KioskContext ctx
) : IServiceService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var organization = ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(o => o.Id == payload.OrganizationId);
        if(organization is null)
            return new NotFoundEx("Organization not found");

        var service = new ServiceModel
        {
            Name=payload.Name,
            Image=payload.Image,
            Available=payload.Available ?? true,
            Organization=organization,
            OrganizationId=organization.Id
        };

        ctx.Services.Add(service);
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(service);
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        List<GetPayload> value = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => available == null ? true : s.Available == available)
            .Select(s => GetPayload.ToDto(s))
            .ToListAsync(cancellationToken);
        return new GenericListPayload<GetPayload>{Total = value.Count, List = value};
    }

    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Include(s => s.Variants)    
                .ThenInclude(v => v.PriceHistoryVariants)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if(service == null)
            return new NotFoundEx("Referenced service not found");
        
        return GetPayload.ToDto(service);
    }

    public async Task<Result<GetPayload>> Update(Guid id, UpdatePayload payload, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.Id == id)
            .FirstOrDefault();
        
        if(service == null)
            return new NotFoundEx("Referenced Service not found");
        
        if(payload.Name.HasChanged)
            service.Name = payload.Name.Value;
        if(payload.Image.HasChanged)
            service.Image = payload.Image.Value;
        if(payload.Available.HasChanged)
            service.Available = payload.Available.Value;
        
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(service);
    }
    public async Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var service = ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == id)
            .FirstOrDefault();
        if(service == null)
            return new NotFoundEx("Referenced service not found");
            
        service.DisabledAt = DateTime.UtcNow;
        await ctx.SaveChangesAsync(cancellationToken);

        return GetPayload.ToDto(service);
    }
}