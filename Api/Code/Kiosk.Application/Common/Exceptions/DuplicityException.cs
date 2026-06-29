
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Messages;

namespace Kiosk.Application.Common.Exceptions;

public class DuplicityException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.Conflict, message, details) { }
