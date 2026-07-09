using Kiosk.Application.Features.Auth_;

namespace Kiosk.Application.Payloads._Misc;

public record PasswordPayload
{
    public required string To {get;init;}
    public required string From {get;init;}
    public required string Subject {get;init;}
    public required GetTokenPayload Token {get;init;}
    public required int Minutes {get;init;}
}