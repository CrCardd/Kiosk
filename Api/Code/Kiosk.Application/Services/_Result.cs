using System.Diagnostics.CodeAnalysis;

namespace Kiosk.Application.Services;

public record Result<T>(
    bool Ok,
    string? Message,
    T? Value
)
{
    [MemberNotNullWhen(false, nameof(Message))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => Ok;
    public static Result<T> Fail(string message)
        => new(false, message, default);
    public static implicit operator Result<T>(string error)
        => Fail(error);
    public static implicit operator Result<T>(T value)
        => new(true, null, value);
}