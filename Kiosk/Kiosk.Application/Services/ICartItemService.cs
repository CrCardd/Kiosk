using Kiosk.Application.Payloads.CartItem;

namespace Kiosk.Application.Services;

public interface ICartItemService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}