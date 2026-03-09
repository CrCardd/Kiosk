
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.VariantIngredient_.Create;

public class Create(
    IVariantIngredientService variantIngredientService
) : BaseFeature
{
    public async Task<Result<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var response = await variantIngredientService.Create(
            new(
                request.Available ?? true,
                request.VariantId,
                request.IngredientId
            ),
            cancellationToken
        );
        if(!response.IsSuccess)
            return response.Message;
        return new CreateResponse(
            response.Value.Id,
            response.Value.Available,
            response.Value.VariantId,
            response.Value.IngredientId
        );
    }
}
