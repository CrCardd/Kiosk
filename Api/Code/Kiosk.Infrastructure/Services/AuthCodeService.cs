using System.CodeDom;
using Kiosk.Application.Payloads.AuthCode;
using Kiosk.Application.Services;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

public class AuthCodeService(
    KioskContext ctx
) : IAuthCodeService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var check = await ctx.AuthCodes
            .Where(ac => ac.DisabledAt == null)
            .FirstOrDefaultAsync(ac => ac.Email == payload.Email);
        if(check is not null)
            ctx.AuthCodes.Remove(check);
        
        var authcode = new AuthCodeModel
        {
            Code = payload.Code,
            Email = payload.Email,
            StartDate = payload.StartDate,
            EndDate = payload.EndDate,
        };

        ctx.AuthCodes.Add(authcode);
        await ctx.SaveChangesAsync(cancellationToken);

        return GetPayload.FromGetPayload(authcode);
    }
}