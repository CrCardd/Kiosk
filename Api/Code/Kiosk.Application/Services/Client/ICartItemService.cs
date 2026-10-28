using Kiosk.Application.Payloads.CartItem;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Client;

public interface ICartItemService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}