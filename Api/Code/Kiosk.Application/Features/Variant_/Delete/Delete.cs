
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Variant_.Delete;

public class Delete(
    IVariantClientService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await variantService.Delete(id, cancellationToken);
        return response;
    }
}
