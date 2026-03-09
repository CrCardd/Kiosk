
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;
using Kiosk.Domain.Payloads.Update;

namespace Kiosk.Domain.Services;

public interface IServiceService : IBaseService
{
    public Task<Result<ServiceGetPayload>> Create(ServiceCreatePayload payload, CancellationToken cancellationToken);
    public Task<Result<IReadOnlyList<ServiceGetPayload>>> GetAll(bool? available, CancellationToken cancellationToken);
    public Task<Result<ServiceGetPayload>> Update(Guid Id, ServiceUpdatePayload payload, CancellationToken cancellationToken);
}