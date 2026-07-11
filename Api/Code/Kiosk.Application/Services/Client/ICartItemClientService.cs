using Kiosk.Application.Payloads.CartItem;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Client;

public interface ICartItemClientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}