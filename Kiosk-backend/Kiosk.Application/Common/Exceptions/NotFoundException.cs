
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Messages;

namespace Kiosk.Application.Common.Exceptions;

public class NotFoundException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.NotFound, message, details) { }
