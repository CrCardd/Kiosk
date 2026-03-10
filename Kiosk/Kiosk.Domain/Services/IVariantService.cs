
using Kiosk.Domain.Payloads.Variant;

namespace Kiosk.Domain.Services;

public interface IVariantService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    public Task<Result<IReadOnlyCollection<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken);
}