
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Service_.GetById;

public class GetById(
    IServiceClientService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await serviceService.GetById(id, cancellationToken);
        return response;
    }
}
