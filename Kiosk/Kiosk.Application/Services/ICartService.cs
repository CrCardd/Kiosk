
using Kiosk.Application.Payloads.Cart;

namespace Kiosk.Application.Services;

public interface ICartService : IBaseService
{
    public Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken);
    public Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken);
}