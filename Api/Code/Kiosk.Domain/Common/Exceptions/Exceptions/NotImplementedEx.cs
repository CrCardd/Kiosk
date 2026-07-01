using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class NotImplementedEx(
    string message = "not implemented"
) : BaseException(message, Status.NotImplemented, false);