using Kiosk.Application.Payloads.Provider;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Application.Services.Client;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services.Client;

public class OAuthProviderClientService(
    KioskContext ctx
) : IOAuthProviderClientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var exists = ctx.Providers.Any(p => 
            p.Subject == payload.Subject
            && p.Type == payload.Type
        );
        if(exists)
            throw new ConflictEx("provider already exists");

        var user = await ctx.Users
            .FirstOrDefaultAsync(u => u.Email == payload.Email, cancellationToken);
        if(user is null)
            throw new NotFoundEx("user not found");
        
        var provider = new OAuthProviderModel
        {
            Name = payload.Name,
            Email = payload.Email,
            Type = payload.Type,
            Subject = payload.Subject,
            Picture = payload.Picture,
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