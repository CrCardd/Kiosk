using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.Segment;

public record GetPayload
{
    public Guid Id {get;init;}
    public required string Name {get;init;}

    public static GetPayload ToDto(SegmentModel segment)
    {
        return new GetPayload
        {
            Id = segment.Id,
            Name = segment.Name
        };
    }
}