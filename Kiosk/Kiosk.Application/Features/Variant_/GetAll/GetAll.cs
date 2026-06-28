
using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Variant_.GetAll;

public class GetAll(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(bool? available, CancellationToken cancellationToken)
    {
        var response = await variantService.GetAll(available, cancellationToken);
        return response;
    }
}
