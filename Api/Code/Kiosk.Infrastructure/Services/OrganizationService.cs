using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

public class OrganizationService
(
    KioskContext ctx
) : IOrganizationService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var organization = new OrganizationModel
        {
            Name = payload.Name,
            Password = payload.Password
        };

        ctx.Organizations.Add(organization);
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(organization);
    }


    public async Task<Result<GetPayload>> GetByName(string name, CancellationToken cancellationToken)
    {
        var organization = await ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(o => o.Name == name);
        if(organization is null)
            return new NotFoundEx("Organization not found");
        return GetPayload.ToDto(organization);
    }
}