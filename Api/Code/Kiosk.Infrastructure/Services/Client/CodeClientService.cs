using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Application.Services.Client;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class CodeClientService(
    KioskContext ctx
) : ICodeClientService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var organization = await ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
                // o => o.Id == apiCtx.OrganizationId, 
            cancellationToken);
        if(organization is null)
            throw new NotFoundEx("Organization not found!");
        
        var code = new CodeModel    
        {
            Code = payload.Code,
            Organization = organization,
            OrganizationId = organization.Id,
            StartDate = payload.StartDate,
            EndDate = payload.EndDate
        };

        ctx.Codes.Add(code);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(code));
    }

    public async Task<Result<ICollection<GetPayload>>> GetAll(CancellationToken cancellationToken)
    {

        ICollection<GetPayload> all = await ctx.Codes
            .Where(c => c.DisabledAt == null)
            .Include(c => c.Organization)
            .Select(c => GetPayload.ToDto(c))
            .ToListAsync(cancellationToken);
            
        return Result.Ok(all);
    }
}