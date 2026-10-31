using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.Segment;
using Kiosk.Application.Services;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Kiosk.Domain.Common.Enums;

namespace Kiosk.Infrastructure.Services.Client;

public class SegmentService
(
    KioskContext context
) : BaseService<SegmentModel, GetPayload>(context, "segment"), 
    ISegmentService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var segment = new SegmentModel
        {
            Name = payload.Name,
            OrganizationId = payload.BelongsTo
        };
        var user = await ctx.Users
            .FirstOrDefaultAsync(u => u.Id == payload.CreatedBy, cancellationToken);
        if(user == null)
            throw new NotFoundEx("User not found");

        segment.UserSegments.Add(
            new UserSegmentModel
            {
                User = user,
                UserId = user.Id,
                Segment = segment,
                SegmentId = segment.Id,
                Roles = SegmentRole.Owner
            }
        );


        ctx.Segments.Add(segment);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(segment));
    }
    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var segment = await ctx.Segments
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(cancellationToken);
        if(segment is null)
            throw new NotFoundEx("segment not found");
        
        if(payload.Name.HasChanged)
            segment.Name = payload.Name.Value;
            
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(segment);
    }
}