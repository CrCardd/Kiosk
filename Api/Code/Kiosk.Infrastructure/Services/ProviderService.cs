using Kiosk.Application.Payloads.Provider;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

public class ProviderService(
    KioskContext ctx
) : IProviderService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var exists = ctx.Providers.Any(p => 
            p.Subject == payload.Subject
            && p.Type == payload.Type
        );
        if(exists)
            throw new ConflictEx("provider already exists");

        var organization = await ctx.Organizations
            .FirstOrDefaultAsync(o => o.Id == payload.OrganizationId);
        if(organization is null)
            throw new NotFoundEx("organization not found");
        
        var provider = new ProviderModel
        {
            Name = payload.Name,
            Email = payload.Email,
            Type = payload.Type,
            Subject = payload.Subject,
            Picture = payload.Picture,

            Organization = organization,
            OrganizationId = organization.Id,
        };

        ctx.Providers.Add(provider);
        await ctx.SaveChangesAsync(cancellationToken);

        return Result.Created(GetPayload.ToDto(provider));
    }

    public Task<bool> ExistsBySubjectAsync(string subject, CancellationToken cancellationToken)
    {
        return ctx.Providers.AnyAsync(p => p.Subject == subject, cancellationToken);
    }
}