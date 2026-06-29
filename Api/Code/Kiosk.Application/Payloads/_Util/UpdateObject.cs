using System.Diagnostics.CodeAnalysis;

namespace Kiosk.Application.Payloads._Util;

public record UpdateObject<T>
{
    [MemberNotNullWhen(true, nameof(Value))]
    public required bool HasChanged {get;init;}
    public required T Value {get;init;}
}