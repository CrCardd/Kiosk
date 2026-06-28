
using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Payloads.Service;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Service_.GetAll;

public class GetAll(
    IServiceService serviceService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(bool? available, CancellationToken cancellationToken)
    {
        var response = await serviceService.GetAll(available, cancellationToken);
        return response;
    }
}
