using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class BadRequestEx(
    string message = "invalid arguments"
) : BaseException(message, Status.BadRequest);