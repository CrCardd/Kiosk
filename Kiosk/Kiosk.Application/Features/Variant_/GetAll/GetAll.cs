
using System.Net;
using Kiosk.Domain.Payloads._Misc;
using Kiosk.Domain.Payloads.Variant;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Variant_.GetAll;

public class GetAll(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GenericListPayload<GetPayload>>> ExecuteAsync(bool? available, CancellationToken cancellationToken)
    {
        var response = await variantService.GetAll(available, cancellationToken);
        if(!response.IsSuccess)
            return response.Message;
        return response.Value;
    }
}
