using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

public class CodeService(
    KioskContext ctx
) : ICodeService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var organization = ctx.Organizations
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(o => o.Id == payload.OrganizationId);
        if(organization is null)
            return "Organization not found!";
        
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
        return GetPayload.ToDto(code);
    }

    public async Task<Result<ICollection<GetPayload>>> GetAll(CancellationToken cancellationToken)
    {
        return await ctx.Codes
            .Where(c => c.DisabledAt == null)
            .Select(c => GetPayload.ToDto(c))
            .ToListAsync(cancellationToken);
    }
}