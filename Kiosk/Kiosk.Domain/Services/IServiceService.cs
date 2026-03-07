using Kiosk.Domain.Payloads.Models;
using Kiosk.Domain.Payloads.Models.Updates;

namespace Kiosk.Domain.Services;

public interface IServiceService : IBaseService
{
    public Task<ServicePayload?> Create(ServicePayload payload, CancellationToken cancellationToken);
    public Task<ICollection<ServicePayload>> GetAll(bool? available);
    public Task<ServicePayload?> Update(Guid Id, ServiceUpdatePayload payload, CancellationToken cancellationToken);
}