
using Kiosk.Domain.Interfaces;
using Kiosk.Application.Payloads.Provider;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IOAuthProviderService : IBaseService<OAuthProviderModel, GetPayload>
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<bool> ExistsBySubjectAsync(string subject, CancellationToken cancellationToken);
}