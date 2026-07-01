using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class ForbiddenEx(
    string message = "forbidden"
) : BaseException(message, Status.Forbidden, false);