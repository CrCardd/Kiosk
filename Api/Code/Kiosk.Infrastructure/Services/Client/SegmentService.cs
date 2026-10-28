using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.Segment;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services.Client;

public class SegmentService
(
    KioskContext ctx
) : ISegmentService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var segment = new SegmentModel
        {
            Name = payload.Name,
        };

        ctx.Segments.Add(segment);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(segment));
    }
    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var segment = await ctx.Segments
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
                cancellationToken
            );
        if(segment is null)
            throw new NotFoundEx("segment not found");
        
        if(payload.Name.HasChanged)
            segment.Name = payload.Name.Value;
            
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(segment);
    }


    public GetPayload Get(Expression<Func<SegmentModel, bool>> predicate)
    {
        var segment = ctx.Segments
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(segment is null)
            throw new NotFoundEx("segment not found");
        return GetPayload.ToDto(segment);
    }

    public bool TryGet(Expression<Func<SegmentModel, bool>> predicate, [NotNullWhen(true)] out GetPayload? getPayload)
    {
        var segment = ctx.Segments
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(segment is null)
        {            
            getPayload = null;
            return false;
        }
        getPayload = GetPayload.ToDto(segment);
        return true;
    }
}