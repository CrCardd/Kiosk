
using Kiosk.Domain.Payloads.Variant;

namespace Kiosk.Application.Features.Variant_.GetAll;

public record GetAllResponse(
    int Count,
    IReadOnlyCollection<GetPayload> Variants
);
