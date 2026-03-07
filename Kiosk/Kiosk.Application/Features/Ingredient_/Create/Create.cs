
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Ingredient_.Create;

public class Create(
    IIngredientService ingredientService
) : BaseFeature
{
    public async Task<BaseResponse<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        
    }
}
