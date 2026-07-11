namespace Kiosk.Application.Features.Auth_;

public record ProviderRequest
{
    public required string IdToken {get;init;}
    public required string Provider {get;init;}
}