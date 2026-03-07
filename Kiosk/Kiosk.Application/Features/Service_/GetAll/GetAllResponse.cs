
using Kiosk.Domain.Payloads.Models;

namespace Kiosk.Application.Features.Service_.GetAll;

public record GetAllResponse(
    ICollection<ServicePayload> Services
);
