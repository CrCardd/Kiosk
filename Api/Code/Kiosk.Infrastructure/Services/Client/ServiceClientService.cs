
using Kiosk.Domain.Models;
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class ServiceClientService(
    KioskContext ctx
) : IServiceClientService
{

    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var organization = await ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
                // o => o.Id == OrganizationId, 
                cancellationToken
            );
        if(organization is null)
            throw new NotFoundEx("Organization not found");

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
        return Result.Created(GetPayload.ToDto(service));
    }

    public async Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken)
    {
        List<GetPayload> value = await ctx.Services
            .Where(s => s.DisabledAt == null)
            // .Where(s => s.OrganizationId == OrganizationId)
            .Where(s => available == null ? true : s.Available == available)
            .Select(s => GetPayload.ToDto(s))
            .ToListAsync(cancellationToken);
        var all = new GenericListPayload<GetPayload>{Total = value.Count, List = value};
        return Result.Ok(all);
    }

    public async Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            .Where(s => s.DisabledAt == null)
            // .Where(s => s.OrganizationId == OrganizationId)
            .Include(s => s.Variants)
                .ThenInclude(v => v.PriceHistoryVariants)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        
        if(service == null)
            throw new NotFoundEx("Referenced service not found");
        
        return Result.Ok(GetPayload.ToDto(service));
    }

    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            // .Where(s => s.OrganizationId == OrganizationId)
            .Where(s => s.Id == payload.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(service == null)
            throw new NotFoundEx("Referenced Service not found");
        
        if(payload.Name.HasChanged)
            service.Name = payload.Name.Value;
        if(payload.Image.HasChanged)
            service.Image = payload.Image.Value;
        if(payload.Available.HasChanged)
            service.Available = payload.Available.Value;
        
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Ok(GetPayload.ToDto(service));
    }
    public async Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var service = await ctx.Services
            .Where(s => s.DisabledAt == null)
            .Where(s => s.Id == id)
            // .Where(s => s.OrganizationId == OrganizationId)
            .FirstOrDefaultAsync(cancellationToken);
        if(service == null)
            throw new NotFoundEx("Referenced service not found");
            
        service.DisabledAt = DateTime.UtcNow;
        await ctx.SaveChangesAsync(cancellationToken);

        return Result.Ok(GetPayload.ToDto(service));
    }
}