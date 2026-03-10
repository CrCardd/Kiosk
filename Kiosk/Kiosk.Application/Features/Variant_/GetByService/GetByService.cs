
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Variant;
using Kiosk.Domain.Services;

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
