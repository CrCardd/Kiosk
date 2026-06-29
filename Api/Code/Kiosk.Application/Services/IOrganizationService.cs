using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Payloads.Organization;

namespace Kiosk.Application.Services;

public interface IOrganizationService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    // Task<Result<>> GenerateCode();

    Task<Result<GetPayload>> GetByName(string name, CancellationToken cancellationToken);
}