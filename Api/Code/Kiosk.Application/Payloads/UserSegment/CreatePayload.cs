using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Payloads.UserSegment;

public record CreatePayload
{
    public required Guid UserId {get;init;}
    public required Guid SegmentId {get;init;}
    public required SegmentRole Roles {get;init;}
}