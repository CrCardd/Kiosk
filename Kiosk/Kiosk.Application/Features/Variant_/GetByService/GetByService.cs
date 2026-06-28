
using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Variant_.GetByService;

public class GetByService(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(Guid serviceId, CancellationToken cancellationToken)
    {
        var response = await variantService.GetByService(serviceId, cancellationToken);
        return response;
    }
}
