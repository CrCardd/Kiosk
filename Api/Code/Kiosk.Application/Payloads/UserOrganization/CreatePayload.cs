using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Payloads.UserOrganization;

public record CreatePayload
{
    public required Guid UserId {get;init;}
    public required Guid OrganizationId {get;init;}
    public required OrganizationRole Roles {get;init;}
}