namespace Kiosk.Domain.Common.Enums;

public enum Role
{
    Token,
    Organization
}

public static class Roles
{
    public static string GetRoleName(Role role)
    {
        return (role) switch
        {
            Role.Organization => "organization",
            Role.Token => "token",
            _ => "invalid"
        };

    }
}