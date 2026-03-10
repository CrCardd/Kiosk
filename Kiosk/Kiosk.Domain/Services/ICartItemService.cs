using Kiosk.Domain.Payloads.CartItem;

namespace Kiosk.Domain.Services;

public interface ICartItemService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}