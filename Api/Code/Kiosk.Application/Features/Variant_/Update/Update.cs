
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Variant_.Create;

public class Update(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantService.Update(request,cancellationToken);
        return response;
    }
}
