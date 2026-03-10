
using Kiosk.Domain.Payloads.VariantIngredient;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.VariantIngredient_.Create;

public class Create(
    IVariantIngredientService variantIngredientService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await variantIngredientService.Create(request,cancellationToken);
        if(!response.IsSuccess)
            return response.Message;
        return response.Value;
    }
}
