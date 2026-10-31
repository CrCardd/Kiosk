namespace Kiosk.Domain.Common.Enums;

public enum TokenType
{
    Super,

    Kiosk,
    Session,
    Segment,
    Organization,
    User,

    Invalid
}

public static class TokenTypes
{
    public static string GetTokenTypeName(TokenType role)
    {
        return role switch
        {
            TokenType.Super => "super",

            TokenType.Segment => "segment",
            TokenType.Organization => "organization",
            TokenType.User => "user",
            TokenType.Session => "session",
            TokenType.Kiosk => "kiosk",

            _ => "invalid"
        };
    }
    public static TokenType GetTokenType(string role)
    {
        return role switch
        {
            "super"=> TokenType.Super, 

            "segment"=> TokenType.Segment, 
            "organization"=> TokenType.Organization, 
            "user"=> TokenType.User, 
            "session"=> TokenType.Session,
            "kiosk"=> TokenType.Kiosk,

            _ => TokenType.Invalid
        };
    }
}

public static class TokenTypeExtension
{
    public static string ToMyString(this TokenType role)
        => TokenTypes.GetTokenTypeName(role);
    
}