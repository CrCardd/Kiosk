using System.Diagnostics.CodeAnalysis;
using Kiosk.Application.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Services;


public class Result<T>(
    bool ok,
    string message,
    T? value,
    Status status
) : IResultBase
{
    private bool Ok {get;} = ok;
    public string Message {get;} = message;
    public Status Status {get;} = status;

    public T? Value { get; } = value;
    object? IResultBase.Value => Value;

    [MemberNotNullWhen(false, nameof(Message))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => Ok;
    public static implicit operator Result<T>(T value)
        => new(true, "", value, Status.Ok);

    public static implicit operator Result<T>(BaseException exception)
        => new(exception.Ok, exception.Message, default, exception.StatusCode);
}