using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.UserSegment;

public record GetPayload : IBaseGetPayload<UserSegmentModel, GetPayload>
{
    public required Guid Id {get;init;}
    public required Guid UserId {get;init;}
    public required Guid SegmentId {get;init;}
    public required SegmentRole Roles {get;init;}

    public static GetPayload ToDto(UserSegmentModel userSegmentModel)
    {
        return new GetPayload
        {
            Id = userSegmentModel.Id,
            UserId = userSegmentModel.UserId,
            SegmentId = userSegmentModel.SegmentId,
            Roles = userSegmentModel.Roles
        };
    }
}