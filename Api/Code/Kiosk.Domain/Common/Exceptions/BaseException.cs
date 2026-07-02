using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public abstract class BaseException : Exception
{
    public readonly Status Status; 
    protected BaseException(string message, Status statusCode) : base(message)
    {
        Status = statusCode;
    }
}