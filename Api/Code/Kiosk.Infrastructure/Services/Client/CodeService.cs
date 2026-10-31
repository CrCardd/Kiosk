using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Models;
using Kiosk.Application.Services.Client;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Services.Client;

public class CodeService(
    KioskContext context
) : BaseService<CodeModel, GetPayload>(context, "code"), 
    ICodeService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var segment = await ctx.Segments
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
            cancellationToken);
        if(segment is null)
            throw new NotFoundEx("segment not found!");
        
        var code = new CodeModel    
        {
            Code = payload.Code,
            Segment = segment,
            SegmentId = segment.Id,
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
            .Include(c => c.Segment)
            .Select(c => GetPayload.ToDto(c))
            .ToListAsync(cancellationToken);
            
        return Result.Ok(all);
    }
}