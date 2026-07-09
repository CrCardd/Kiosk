namespace Kiosk.Application.Payloads._Misc;

public record VerificationCodePayload
{
    public required string Code {get;init;}
    public required int Minutes {get;init;}
    public required string To {get;init;}
    public required string From {get;init;}
    public required string Subject {get;init;}
}