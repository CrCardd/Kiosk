
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Service_.Create;

public class Create(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await serviceService.Create(request, cancellationToken);
        return response;
    }
}
