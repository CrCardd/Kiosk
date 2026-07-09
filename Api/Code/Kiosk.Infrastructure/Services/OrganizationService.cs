using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
namespace Kiosk.Infrastructure.Services;

public class OrganizationService
(
    KioskContext ctx
) : IOrganizationService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var exists = ctx.Organizations.Any(o => o.Email == payload.Email);
        if(exists)
            throw new ConflictEx("email already in use");

        var organization = new OrganizationModel
        {
            Name = payload.Name,
            Email = payload.Email,
            Password = payload.Password
        };

        ctx.Organizations.Add(organization);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(organization));
    }
    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var organization = ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(o => o.Id == payload.Id);
        if(organization is null)
            throw new NotFoundEx("organization not found");
        
        if(payload.Name.HasChanged)
            organization.Name = payload.Name.Value;
        if(payload.Email.HasChanged)
            organization.Email = payload.Email.Value;
        if(payload.Password.HasChanged)
            organization.Password = payload.Password.Value; 
            
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

    public GetPayload Get(Func<OrganizationModel, bool> value, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}