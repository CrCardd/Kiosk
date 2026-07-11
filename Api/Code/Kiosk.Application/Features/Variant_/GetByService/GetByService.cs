
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services.Client;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Variant_.GetByService;

public class GetByService(
    IVariantClientService variantService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(Guid serviceId, CancellationToken cancellationToken)
    {
        var response = await variantService.GetByService(serviceId, cancellationToken);
        return response;
    }
}
