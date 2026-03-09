
using Kiosk.Domain.Services;

namespace Kiosk.Application.Features.Ingredient_.Create;

public class Create(
    IIngredientService ingredientService
) : BaseFeature
{
    public async Task<Result<CreateResponse>> ExecuteAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var response = await ingredientService.Create(
            new(
                request.Name,
                request.Price,
                request.Available ?? true,
                request.ServiceId,
                request.Quantity
            ),
        cancellationToken
        );

        if(!response.IsSuccess)
            return response.Message;
        return new CreateResponse(
            response.Value.Id,
            response.Value.Name,
            response.Value.Price,
            response.Value.Quantity,
            response.Value.ServiceId
        );
    }
}
