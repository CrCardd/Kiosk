
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Variant;

namespace Kiosk.Application.Services;

public interface IVariantService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GenericListPayload<GetPayload>>> GetAll(bool? available, CancellationToken cancellationToken);
    Task<Result<GetPayload>> GetById(Guid id, CancellationToken cancellationToken);
    Task<Result<GenericListPayload<GetPayload>>> GetByService(Guid serviceId, CancellationToken cancellationToken);
    Task<Result<GetPayload>> Update(Guid id, UpdatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> Delete(Guid id, CancellationToken cancellationToken);
}