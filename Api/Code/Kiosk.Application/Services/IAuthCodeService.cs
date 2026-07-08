using Kiosk.Application.Payloads.AuthCode;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services;

public interface IAuthCodeService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}