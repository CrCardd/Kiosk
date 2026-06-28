
using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Payloads.Variant;

namespace Kiosk.Application.Services;

public interface IVariantService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    public Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken);
    public Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken);
    public Task<Result<GenericListPayload<GetPayload>>> GetByService(Guid serviceId, CancellationToken cancellationToken);
    public Task<Result<GetPayload>> Update(Guid id, UpdatePayload payload, CancellationToken cancellationToken);
    public Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken);
}