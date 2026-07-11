using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Infrastructure.Context;

public class DesignApiContext : IApiContext
{
    public Guid OrganizationId => Guid.Empty;
    public List<Role> Roles => new List<Role>();
    public Guid? CartId => Guid.Empty;
    public string Email => string.Empty;

}