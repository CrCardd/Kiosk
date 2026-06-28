using Kiosk.Domain.Common.Attributes;

namespace Kiosk.Domain.Common.Enums;

public enum Roles
{
    [StringAttribute("token")] Token,
    [StringAttribute("organization")] Organization
}