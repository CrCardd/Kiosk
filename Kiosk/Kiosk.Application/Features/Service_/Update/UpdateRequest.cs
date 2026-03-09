
using Kiosk.Domain.Payloads.Update;

namespace Kiosk.Application.Features.Service_.Update;

public record UpdateRequest(
    Guid Id,
    ServiceUpdatePayload Updates
);
