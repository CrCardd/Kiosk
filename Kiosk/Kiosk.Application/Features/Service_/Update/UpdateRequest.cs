
using Kiosk.Domain.Payloads.Service;

namespace Kiosk.Application.Features.Service_.Update;

public record UpdateRequest(
    Guid Id,
    UpdatePayload Updates
);
