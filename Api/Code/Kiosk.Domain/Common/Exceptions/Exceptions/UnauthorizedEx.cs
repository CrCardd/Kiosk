using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class UnauthorizedEx(
    string message = "unauthorized"
) : BaseException(message, Status.Unauthorized, false);