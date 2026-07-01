using Kiosk.Application.Common.Enums;

namespace Kiosk.Application.Features.Auth_;

public record CreateTokenPayload
{
    public required Role Role {get;init;}
    public required Guid OrganizationId {get;init;}
}