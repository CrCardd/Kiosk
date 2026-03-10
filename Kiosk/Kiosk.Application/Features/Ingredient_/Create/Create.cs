
using Kiosk.Domain.Payloads.Ingredient;
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Ingredient_.Create;

public class Create(
    IIngredientService ingredientService
) : BaseFeature
{
    public async Task<Result<GetPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var response = await ingredientService.Create(request,cancellationToken);
        return response;
    }
}
