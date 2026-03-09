
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;

namespace Kiosk.Domain.Services;

public interface ICartService : IBaseService
{
    public Task<Result<CartGetPayload>> Start(CartCreatePayload payload, CancellationToken cancellationToken);
}