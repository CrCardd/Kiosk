
using Kiosk.Application.Payloads.Code;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services.Client;

public interface ICodeService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<ICollection<GetPayload>>> GetAll(CancellationToken cancellationToken);
}