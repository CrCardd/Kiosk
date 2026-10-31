using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Enums;

namespace Kiosk.Infrastructure.Services.Client;

public class OrganizationService
(
    KioskContext context
) : BaseService<OrganizationModel, GetPayload>(context, "organization"), 
    IOrganizationService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {

        var organization = new OrganizationModel
        {
            Name = payload.Name,
        };
        var user = await ctx.Users
            .FirstOrDefaultAsync(u => u.Id == payload.CreatedBy, cancellationToken);
        if(user == null)
            throw new NotFoundEx("User not found");

        organization.UserOrganizations.Add(
            new UserOrganizationModel
            {
                User = user,
                UserId = user.Id,
                Organization = organization,
                OrganizationId = organization.Id,
                Roles = OrganizationRole.Owner
            }
        );

        ctx.Organizations.Add(organization);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(organization));
    }
    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var organization = await ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(cancellationToken);
        if(organization is null)
            throw new NotFoundEx("organization not found");
        
        if(payload.Name.HasChanged)
            organization.Name = payload.Name.Value;
            
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(organization);
    }
}