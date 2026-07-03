
using Kiosk.Domain.Interfaces;
using Kiosk.Application.Payloads.Provider;

namespace Kiosk.Application.Services;

public interface IProviderService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<bool> ExistsBySubjectAsync(string subject, CancellationToken cancellationToken);
}