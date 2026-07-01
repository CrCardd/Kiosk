using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class InternalServerErrorEx(
    string message = "internal server error"
) : BaseException(message, Status.InternalServerError, false);