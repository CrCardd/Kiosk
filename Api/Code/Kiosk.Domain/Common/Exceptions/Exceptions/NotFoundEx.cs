using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class NotFoundEx(
    string message = "not found"
) : BaseException(message, Status.NotFound, false);