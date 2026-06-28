
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Service_.Delete;

public class Delete(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await serviceService.Delete(id,cancellationToken);
        return response;
    }
}
