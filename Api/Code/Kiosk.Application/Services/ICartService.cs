
using Kiosk.Application.Payloads.Cart;

namespace Kiosk.Application.Services;

public interface ICartService : IBaseService
{
    Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken);
}