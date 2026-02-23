
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Messages;

namespace Kiosk.Application.Common.Exceptions;

public class BadRequestException(
    string message = ExceptionMessage.BadRequest.Default,
    string? details = null
) : AppException(StatusCode.BadRequest, message, details) { }
