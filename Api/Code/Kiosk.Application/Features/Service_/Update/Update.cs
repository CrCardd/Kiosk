
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Service_.Update;

public class Update(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Update(request,cancellationToken);
        return response;
    }
}
