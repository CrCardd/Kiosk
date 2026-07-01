namespace Kiosk.Application.Common.Enums;

public enum Role
{
    Kiosk,
    Organization
}

public static class Roles
{
    public static string GetRoleName(Role role)
    {
        return role switch
        {
            Role.Organization => "organization",
            Role.Kiosk => "kiosk",
            _ => "invalid"
        };

    }
}