namespace Kiosk.Application.Payloads._Util;

public record GenericListPayload<T>
{
    public required int Total {get;init;}
    public required IReadOnlyCollection<T> List {get;init;}
}