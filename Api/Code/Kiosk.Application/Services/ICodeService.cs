
using Kiosk.Application.Payloads.Code;

namespace Kiosk.Application.Services;

public interface ICodeService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<ICollection<GetPayload>>> GetAll(CancellationToken cancellationToken);
}