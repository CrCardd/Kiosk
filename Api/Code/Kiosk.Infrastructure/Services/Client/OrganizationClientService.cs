using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services.Client;

public class OrganizationClientService
(
    KioskContext ctx
) : IOrganizationClientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {

        var organization = new OrganizationModel
        {
            Name = payload.Name,
        };

        ctx.Organizations.Add(organization);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(organization));
    }
    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var organization = await ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
                cancellationToken
            );
        if(organization is null)
            throw new NotFoundEx("organization not found");
        
        if(payload.Name.HasChanged)
            organization.Name = payload.Name.Value;
            
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(organization);
    }


    public GetPayload Get(Expression<Func<OrganizationModel, bool>> predicate)
    {
        var organization = ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(organization is null)
            throw new NotFoundEx("organization not found");
        return GetPayload.ToDto(organization);
    }

    public bool TryGet(Expression<Func<OrganizationModel, bool>> predicate, [NotNullWhen(true)] out GetPayload? getPayload)
    {
        var organization = ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(organization is null)
        {            
            getPayload = null;
            return false;
        }
        getPayload = GetPayload.ToDto(organization);
        return true;
    }
}