
using Kiosk.Application.Payloads.Cart;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface ICartService : IBaseService<CartModel, GetPayload>
{
    Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken);
}