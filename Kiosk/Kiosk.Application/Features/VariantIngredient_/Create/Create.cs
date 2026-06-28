
using Kiosk.Application.Payloads.VariantIngredient;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.VariantIngredient_.Create;

public class Create(
    IVariantIngredientService variantIngredientService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantIngredientService.Create(request,cancellationToken);
        return response;
    }
}
