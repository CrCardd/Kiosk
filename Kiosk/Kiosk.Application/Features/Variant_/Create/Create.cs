
using Kiosk.Domain.Payloads.Variant;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Variant_.Create;

public class Create(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantService.Create(request,cancellationToken);
        return response;
    }
}
