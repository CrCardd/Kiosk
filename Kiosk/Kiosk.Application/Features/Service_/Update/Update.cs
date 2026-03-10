
using Kiosk.Domain.Payloads.Service;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.Update;

public class Update(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Update(id,request,cancellationToken);
        return response;
    }
}
