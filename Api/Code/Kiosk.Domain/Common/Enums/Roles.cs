namespace Kiosk.Domain.Common.Enums;

public enum Role
{
    Super,



    Kiosk,
    Session,
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
            Role.Super => "super",

            Role.Organization => "organization",
            Role.Session => "session",
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
            "super"=> Role.Super, 

            "organization"=> Role.Organization, 
            "session"=> Role.Session,
            "kiosk"=> Role.Kiosk,

            "register"=> Role.Register, 
            "password"=> Role.Password, 
            _ => Role.Invalid
        };
    }
}

public static class RoleExtension
{
    public static string ToMyString(this Role role)
        => Roles.GetRoleName(role);
    
}