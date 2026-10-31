using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Payloads.UserOrganization;

public record GetPayload : IBaseGetPayload<UserOrganizationModel, GetPayload>
{
    public required Guid Id {get;init;}
    public required Guid UserId {get;init;}
    public required Guid OrganizationId {get;init;}
    public required OrganizationRole Roles {get;init;}

    public static GetPayload ToDto(UserOrganizationModel userOrganization)
    {
        return new GetPayload
        {
            Id = userOrganization.Id,
            UserId = userOrganization.UserId,
            OrganizationId = userOrganization.OrganizationId,
            Roles = userOrganization.Roles
        };
    }
}