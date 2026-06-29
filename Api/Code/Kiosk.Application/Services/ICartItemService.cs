using Kiosk.Application.Payloads.CartItem;

namespace Kiosk.Application.Services;

public interface ICartItemService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}