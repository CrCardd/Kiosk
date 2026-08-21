using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Interfaces;

public interface IApiContext
{
    Guid? UserId { get; }
    Guid? CartId { get; }
    Guid? SegmentId { get; }
    Guid? OrganizationId { get; }
    string? Email { get; }
    SegmentRole? SegmentRoles { get; }
    OrganizationRole? OrganizationRoles { get; }
    List<TokenType> TokenTypes { get; }
}