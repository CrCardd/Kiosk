
using Kiosk.Application.Payloads.Cart;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Client;

public interface ICartClientService : IBaseService
{
    Task<Result<GetPayload>> Start(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken);
}