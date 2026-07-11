using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Features.Auth_;

public record CreateTokenPayload
{
    public required List<Role> Roles {get;init;}
    public required string Email {get;init;}
    public required Guid OrganizationId {get;init;}
    public Guid? CartId {get;init;} = null;
}