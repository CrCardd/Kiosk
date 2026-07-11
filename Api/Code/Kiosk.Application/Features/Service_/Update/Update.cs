
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Service_.Update;

public class Update(
    IServiceClientService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Update(request,cancellationToken);
        return response;
    }
}
