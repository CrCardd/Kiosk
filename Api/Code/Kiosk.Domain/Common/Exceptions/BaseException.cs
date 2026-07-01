using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public abstract class BaseException : Exception
{
    public readonly Status StatusCode; 
    public readonly bool Ok; 
    protected BaseException(string message, Status statusCode, bool ok) : base(message)
    {
        StatusCode = statusCode;
        Ok = ok;
    }
}