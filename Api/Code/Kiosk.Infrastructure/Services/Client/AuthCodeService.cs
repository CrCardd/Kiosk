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

public class AuthCodeService(
    KioskContext context
) : BaseService<AuthCodeModel, GetPayload>(context, "authCode"), 
    IAuthCodeService
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
}