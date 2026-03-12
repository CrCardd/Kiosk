
using Kiosk.Domain.Payloads.Variant;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Variant_.Create;

public class Update(
    IVariantService variantService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(Guid id, UpdatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantService.Update(id,request,cancellationToken);
        return response;
    }
}
