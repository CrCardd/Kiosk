namespace Kiosk.Domain.Payloads._Misc;

public record GenericListPayload<T>(
    int Total,
    IReadOnlyCollection<T> List
);