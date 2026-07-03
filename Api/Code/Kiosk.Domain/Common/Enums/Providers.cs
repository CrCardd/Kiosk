namespace Kiosk.Domain.Common.Enums;

public enum ProviderType
{
    Google,

    Invalid
}

public static class ProviderTypes
{
    public static string GetProviderName(ProviderType provider)
    {
        return provider switch
        {
            ProviderType.Google => "google",
            _ => "invalid"
        };
    }
    public static ProviderType GetProviderType(string provider)
    {
        return provider switch
        {
            "google" => ProviderType.Google,
            _ => ProviderType.Invalid
        };

    }
}