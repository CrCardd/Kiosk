using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Context;

public class DesignApiContext : IApiContext
{
    public Guid? UserId => Guid.Empty;
    public TokenType TokenType => TokenType.Invalid;
    public TokenPurpose TokenPurpose => TokenPurpose.Invalid;
    public Guid? CartId => Guid.Empty;
    public string Email => string.Empty;
    public Guid? SegmentId => Guid.Empty;
    public Guid? OrganizationId => Guid.Empty;
    public SegmentRole? SegmentRoles => null;
    public OrganizationRole? OrganizationRoles => null;
    public DateTimeOffset? ExpiresAt => DateTimeOffset.MinValue;
}