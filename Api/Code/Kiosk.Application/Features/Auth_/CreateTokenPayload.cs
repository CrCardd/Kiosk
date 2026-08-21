using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Features.Auth_;

public record CreateTokenPayload
{
    public required List<TokenType> TokenTypes {get;init;}
    public string? Email {get;init;} = null;
    public Guid? UserId {get;init;} = null;
    public Guid? SegmentId {get;init;} = null;
    public Guid? OrganizationId {get;init;} = null;
    public Guid? CartId {get;init;} = null;

    public OrganizationRole? OrganizationRole { get; init; } = null;
    public SegmentRole? SegmentRole { get; init; } = null;
}