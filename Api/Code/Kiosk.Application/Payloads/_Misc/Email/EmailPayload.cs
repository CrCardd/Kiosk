namespace Kiosk.Application.Payloads._Misc;

public record EmailPayload
{
    public required string To {get;init;}
    public required string From {get;init;}
    public required string Subject {get;init;}
    public string? Body {get;init;}
}