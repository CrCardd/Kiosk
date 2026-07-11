
using Kiosk.Application.Payloads._Util;
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Variant_.GetAll;

public class GetAll(
    IVariantClientService variantService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(bool? available, CancellationToken cancellationToken)
    {
        var response = await variantService.GetAll(available, cancellationToken);
        return response;
    }
}
