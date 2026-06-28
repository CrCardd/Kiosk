namespace Kiosk.Application.Payloads._Misc;

public record GenericListPayload<T>
{
    public required int Total {get;init;}
    public required IReadOnlyCollection<T> List {get;init;}
}