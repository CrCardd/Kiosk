
using Kiosk.Domain.Payloads.Service;

namespace Kiosk.Application.Features.Service_.GetAll;

public record GetAllResponse(
    int Count,
    IReadOnlyCollection<GetPayload> Services
);
