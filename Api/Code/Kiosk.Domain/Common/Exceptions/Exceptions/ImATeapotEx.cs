using Kiosk.Application.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class ImATeapotEx(
    string message = "imateapot"
) : BaseException(message, Status.ImATeapot, false);