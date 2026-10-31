using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Segment;

public record GetPayload : IBaseGetPayload<SegmentModel, GetPayload>
{
    public Guid Id {get;init;}
    public required string Name {get;init;}
    public Guid? OrganizationId {get;init;} = null;

    public static GetPayload ToDto(SegmentModel segment)
    {
        return new GetPayload
        {
            Id = segment.Id,
            Name = segment.Name,
            OrganizationId = segment.OrganizationId
        };
    }
}