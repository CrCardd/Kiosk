namespace Kiosk.Domain.Common.Enums;

public enum TokenPurpose
{
    Access,
    Register,
    Password,

    Invalid
}

public static class TokenPurposes
{
    public static string GetTokenPurposeName(TokenPurpose purpose)
    {
        return purpose switch
        {
            TokenPurpose.Access => "access",
            TokenPurpose.Register => "register",
            TokenPurpose.Password => "password",

            _ => "invalid"
        };
    }
    public static TokenPurpose GetTokenPurpose(string purpose)
    {
        return purpose switch
        {
            "access"=> TokenPurpose.Access, 
            "register"=> TokenPurpose.Register, 
            "password"=> TokenPurpose.Password, 

            _ => TokenPurpose.Invalid
        };
    }
}

public static class TokenPurposeExtension
{
    public static string ToMyString(this TokenPurpose purpose)
        => TokenPurposes.GetTokenPurposeName(purpose);
    
}