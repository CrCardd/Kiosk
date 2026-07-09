namespace Kiosk.Domain.Common.Enums;

public enum Role
{
    Kiosk,
    Organization,


    Register,
    Password,



    Invalid
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
            Role.Password => "password",
            _ => "invalid"
        };
    }
    public static Role GetRole(string role)
    {
        return role switch
        {
            "organization"=> Role.Organization, 
            "kiosk"=> Role.Kiosk, 
            "register"=> Role.Register, 
            "password"=> Role.Password, 
            _ => Role.Invalid
        };
    }
}