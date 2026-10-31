
using Kiosk.Application.Payloads.UserSegment;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IUserSegmentService : IBaseService<UserSegmentModel, GetPayload>
{
    // Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}