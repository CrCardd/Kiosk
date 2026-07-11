
using Kiosk.Application.Payloads.VariantIngredient;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.VariantIngredient_.Create;

public class Create(
    IVariantIngredientClientService variantIngredientService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantIngredientService.Create(request,cancellationToken);
        return response;
    }
}
