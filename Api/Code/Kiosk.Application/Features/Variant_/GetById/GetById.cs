
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Variant_.GetById;

public class GetById(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await variantService.GetById(id, cancellationToken);
        return response;
    }
}
