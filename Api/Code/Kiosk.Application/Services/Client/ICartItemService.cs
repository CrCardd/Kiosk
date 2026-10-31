using Kiosk.Application.Payloads.CartItem;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface ICartItemService : IBaseService<CartItemModel, GetPayload>
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}