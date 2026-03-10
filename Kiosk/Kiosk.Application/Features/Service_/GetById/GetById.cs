
using Kiosk.Domain.Payloads.Service;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Service_.GetById;

public class GetById(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await serviceService.GetById(id, cancellationToken);
        return response;
    }
}
