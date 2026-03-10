
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Service;

namespace Kiosk.Domain.Services;

public interface IServiceService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    public Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken);
    public Task<Result<GetPayload>> Update(Guid Id, UpdatePayload payload, CancellationToken cancellationToken);
}