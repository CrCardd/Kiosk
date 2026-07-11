using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Interfaces;

public interface IApiContext
{
    Guid? OrganizationId { get; }
    Guid? CartId { get; }
    string? Email { get; }
    List<Role> Roles { get; }
}