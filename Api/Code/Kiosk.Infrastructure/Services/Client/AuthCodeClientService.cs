using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.AuthCode;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services.Client;

public class AuthCodeClientService(
    KioskContext ctx
) : IAuthCodeClientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        AuthCodeModel? authCode;

        authCode = await ctx.AuthCodes
            .Where(ac => ac.DisabledAt == null)
            .FirstOrDefaultAsync(ac => ac.Email == payload.Email, cancellationToken);
        if(authCode is null)
        {
            authCode = new AuthCodeModel
            {
                Code = payload.Code,
                Email = payload.Email,
                StartDate = payload.StartDate,
                EndDate = payload.EndDate,
            };
            ctx.AuthCodes.Add(authCode);
        }
        else
            authCode.Code = payload.Code;

        await ctx.SaveChangesAsync(cancellationToken);

        return Result.Ok(GetPayload.ToDto(authCode));
    }

    public async Task<Result<GetPayload>> GetByEmail(string email, CancellationToken cancellationToken)
    {
        var authCode = await ctx.AuthCodes
            .Where(ac => ac.DisabledAt == null)
            .FirstOrDefaultAsync(ac => ac.Email == email, cancellationToken);
        if(authCode is null) throw new NotFoundEx("code not found");
        return Result.Ok(GetPayload.ToDto(authCode));
    }

    public bool TryGet(Expression<Func<AuthCodeModel, bool>> predicate, [NotNullWhen(true)] out GetPayload? getPayload)
    {
        var authCode = ctx.AuthCodes
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(authCode is null)
        {            
            getPayload = null;
            return false;
        }
        getPayload = GetPayload.ToDto(authCode);
        return true;
    }
}