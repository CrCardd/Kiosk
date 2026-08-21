using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Context;

public class DesignApiContext : IApiContext
{
    public Guid? UserId => Guid.Empty;
    public List<TokenType> TokenTypes => new List<TokenType>();
    public Guid? CartId => Guid.Empty;
    public string Email => string.Empty;
    public Guid? SegmentId => Guid.Empty;
    public Guid? OrganizationId => Guid.Empty;
    public SegmentRole? SegmentRoles => null;
    public OrganizationRole? OrganizationRoles => null;
}