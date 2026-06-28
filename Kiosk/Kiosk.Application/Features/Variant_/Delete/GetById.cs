
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.Variant_.Delete;

public class Delete(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await variantService.Delete(id, cancellationToken);
        return response;
    }
}
