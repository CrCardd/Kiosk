
using Kiosk.Domain.Payloads.Get;

namespace Kiosk.Application.Features.Service_.GetAll;

public record GetAllResponse(
    IEnumerable<ServiceGetPayload> Services
);
