namespace Kiosk.Domain.Common.Enums;

public enum Role
{
    Kiosk,
    Organization,
    Register
}

public static class Roles
{
    public static string GetRoleName(Role role)
    {
        return role switch
        {
            Role.Organization => "organization",
            Role.Kiosk => "kiosk",
            Role.Register => "register",
            _ => "invalid"
        };
    }
}