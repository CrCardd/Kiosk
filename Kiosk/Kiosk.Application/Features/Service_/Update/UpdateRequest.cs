
using Kiosk.Domain.Payloads.Models.Updates;

namespace Kiosk.Application.Features.Service_.Update;

public record UpdateRequest(
    Guid Id,
    ServiceUpdatePayload Updates
);
