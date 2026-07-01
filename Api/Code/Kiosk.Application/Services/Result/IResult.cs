using Kiosk.Application.Common.Enums;

namespace Kiosk.Application.Services;


public interface IResultBase{
    bool IsSuccess { get; }
    string Message { get; }
    object? Value { get; }
    Status Status { get; }
}