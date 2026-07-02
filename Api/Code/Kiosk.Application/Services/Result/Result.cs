using System.Diagnostics.CodeAnalysis;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions;

namespace Kiosk.Application.Services;


public static class Result
{
    public static Result<T> New<T>(Status status, T? value = default, string message="")
        => new(message, value, status);


    public static Result<T> Ok<T>(T? value = default, string message="")
        => new(message, value, Status.Ok);
    public static Result<T> Created<T>(T? value = default, string message="")
        => new(message, value, Status.Created);


    public static Result<T> BadRequest<T>(string message="", T? value = default)
        => new(message, value, Status.BadRequest);
    public static Result<T> Unauthorized<T>(string message="", T? value = default)
        => new(message, value, Status.Unauthorized);
    public static Result<T> Forbidden<T>(string message="", T? value = default)
        => new(message, value, Status.Forbidden);
    public static Result<T> NotFound<T>(string message="", T? value = default)
        => new(message, value, Status.NotFound);
    public static Result<T> Conflict<T>(string message="", T? value = default)
        => new(message, value, Status.Conflict);
    public static Result<T> ImATeapot<T>(string message="", T? value = default)
        => new(message, value, Status.BadRequest);
    public static Result<T> InternalServerError<T>(string message="", T? value = default)
        => new(message, value, Status.InternalServerError);
    public static Result<T> NotImplemented<T>(string message="", T? value = default)
        => new(message, value, Status.NotImplemented);
}

public class Result<T>(
    string message,
    T? value,
    Status status
) : IResultBase
{
    public string Message {get;} = message;
    public Status Status {get;} = status;

    public T? Value { get; } = value;
    object? IResultBase.Value => Value;

    [MemberNotNullWhen(false, nameof(Message))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => Status.IsSuccess();

    public static implicit operator Result<T>(T value)
        => new("", value, Status.BadRequest);
    public static implicit operator Result<T>(string message)
        => new(message, default, Status.Ok);
}