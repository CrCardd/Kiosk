using Kiosk.Domain.Payloads.Models;

namespace Kiosk.Domain.Services;

public interface ICartService : IBaseService
{
    public Task<CartPayload?> Start(CartPayload payload, CancellationToken cancellationToken);
}