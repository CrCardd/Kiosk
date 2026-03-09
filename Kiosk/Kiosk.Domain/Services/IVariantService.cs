
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;

namespace Kiosk.Domain.Services;

public interface IVariantService : IBaseService
{
    public Task<Result<VariantGetPayload>> Create(VariantCreatePayload payload, CancellationToken cancellationToken);
}