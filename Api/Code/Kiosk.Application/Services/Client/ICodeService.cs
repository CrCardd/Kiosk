
using Kiosk.Application.Payloads.Code;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface ICodeService : IBaseService<CodeModel, GetPayload>
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<ICollection<GetPayload>>> GetAll(CancellationToken cancellationToken);
}