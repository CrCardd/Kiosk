
using Kiosk.Domain.Payloads.Cart;

namespace Kiosk.Domain.Services;

public interface ICartService : IBaseService
{
    public Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken);
}