
using Kiosk.Application.Payloads.Variant;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Variant_.Create;

public class Create(
    IVariantClientService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantService.Create(request,cancellationToken);
        return response;
    }
}
