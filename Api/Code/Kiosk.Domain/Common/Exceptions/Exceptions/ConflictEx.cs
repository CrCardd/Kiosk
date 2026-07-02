using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions.Exceptions;

public class ConflictEx(
    string message = "conflict"
) : BaseException(message, Status.Conflict);