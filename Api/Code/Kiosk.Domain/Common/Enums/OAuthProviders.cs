namespace Kiosk.Domain.Common.Enums;

public enum OAuthProviderType
{
    Google,

    Invalid
}

public static class OAuthProviderTypes
{
    public static string GetProviderName(OAuthProviderType provider)
    {
        return provider switch
        {
            OAuthProviderType.Google => "google",
            _ => "invalid"
        };
    }
    public static OAuthProviderType GetProviderType(string provider)
    {
        return provider switch
        {
            "google" => OAuthProviderType.Google,
            _ => OAuthProviderType.Invalid
        };

    }
}