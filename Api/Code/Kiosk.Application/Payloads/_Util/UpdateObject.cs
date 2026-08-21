using System.Diagnostics.CodeAnalysis;

namespace Kiosk.Application.Payloads._Util;

public record UpdateObject<T>
{
    [MemberNotNullWhen(true, nameof(Value))]
    public required bool HasChanged {get;init;}
    public required T Value {get;init;}

    public static EmptyType Empty => new();
    public static implicit operator UpdateObject<T>(EmptyType _) 
        => new() { HasChanged = false, Value = default! };
}

public sealed class EmptyType;
public static class UpdateObject
{
    public static EmptyType Empty => new();
}